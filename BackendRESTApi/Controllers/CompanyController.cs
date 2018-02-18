using BackendRESTApi;
using BackendRESTApi.Models.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
 
namespace BackendRESTApi.Controllers
{

    [AllowAnonymous]
    [RoutePrefix("api/Company")]
    public class CompanyController : ApiController
    {
        public ms_company Get(string id)
        {

            ms_company msCompany = null;
            DataPaging<ms_company> dataPaging = new DataPaging<ms_company>();

            using (OASEntities _ent = new OASEntities())
            {
                msCompany = _ent.ms_company.Find(id);

            }


            return msCompany;
        }
         
        // GET api/values
    
        [Route("List")]
        public DataPaging<ms_company> List(HttpRequestMessage v)
        {
            DataPaging<ms_company> dataPaging = new DataPaging<ms_company>();
            dataPaging.meta = new MetaPaging();
            var p = v.Content.ReadAsStringAsync().Result;
            //var xsss = p.Result[""] ; // exam
            NameValueCollection qscoll = HttpUtility.ParseQueryString(p);
            string search = "";
            string orderField = "";
            string orderby = "";
            string page = "";
            string perpage = "";
            string startRow = "";


            search = qscoll["query[generalSearch]"];
            page = qscoll["pagination[page]"];
            perpage = qscoll["pagination[perpage]"];
            orderField = qscoll["sort[field]"];
            orderby = qscoll["sort[sort]"];

            dataPaging.meta.perpage = Convert.ToInt32(perpage);
            dataPaging.meta.page = Convert.ToInt32(page);

            startRow = ((dataPaging.meta.page - 1) * dataPaging.meta.perpage).ToString();
            // datatable[query]:
            //pagination[page]:1
            //pagination[pages]:1
            //pagination[perpage]:5
            //pagination[total]:0
            //sort[field]:CompName
            //sort[sort]:asc
            //query:
            List<ms_company> compList = null;

            using (OASEntities _ent = new OASEntities())
            {

                int totalRow = _ent.Database.SqlQuery<int>(@"  select  count(*) totalRow  from ms_company where compName like '%" + search + "%' or compCode like '%" + search + "%' ").Single();

                compList = _ent.ms_company.SqlQuery(@" select top " + perpage + " * from ( Select *,ROW_NUMBER() OVER(ORDER BY " +
                    orderField + " " + orderby + ") r from ms_company where compName like '%" + search + "%' or compCode like '%" + search + "%'"
                   + " ) company where r > " + startRow + " "
                    ).ToList();

                dataPaging.data = compList;

                dataPaging.meta.total = totalRow;

                dataPaging.meta.pages = Decimal.ToInt32(dataPaging.meta.total / dataPaging.meta.perpage);

            }



            return dataPaging;
        }
        [Route("Insert")]
        public ms_company Insert(ms_company comp)
        {
            using (OASEntities _ent = new OASEntities())
            {
                _ent.ms_company.Add(comp);
                _ent.SaveChanges();
                return comp;
            }
        }


        public ms_company Put(string id, ms_company comp)
        {
            using (OASEntities _ent = new OASEntities())
            {
                ms_company compExits = _ent.ms_company.Find(id);

                if (compExits == null) throw new Exception("id:" + id + " not found ");

                compExits.comp_name = comp.comp_name;
                compExits.update_user = comp.update_user;
                compExits.update_datetime = DateTime.Now;
                _ent.SaveChanges();
                return comp;
            }


        }

        public void Delete(string id)
        {
            using (OASEntities _ent = new OASEntities())
            {
                ms_company comp = _ent.ms_company.Find(id);
                _ent.ms_company.Remove(comp);
                _ent.SaveChanges();
            }
        }
    }
}
