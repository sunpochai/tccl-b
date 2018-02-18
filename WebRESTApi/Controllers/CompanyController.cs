using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApi.Models.Json;
using WebRESTApi;
namespace WebApi.Controllers
{

    [AllowAnonymous]
    [RoutePrefix("api/users")]
    public class CompanyController : ApiController
    {
        public MS_Company Get(string id)
        {

            MS_Company msCompany = null;
            DataPaging<MS_Company> dataPaging = new DataPaging<MS_Company>();

            using (OASEntities _ent = new OASEntities())
            {
                msCompany = _ent.MS_Company.Find(id);

            }


            return msCompany;
        }


        [Route("List")]
        public DataPaging<MS_Company> List(SearchCompDataPaging search)
        {

            List<MS_Company> compList = null;
            DataPaging<MS_Company> dataPaging = new DataPaging<MS_Company>();
            if (search != null)
            {
                using (OASEntities _ent = new OASEntities())
                {
                    compList = _ent.MS_Company.Where(x => x.CompName.Contains(search.compName)).OrderBy(x => x.CompName).ToList();
                    dataPaging.data = compList;
                    dataPaging.meta = new MetaPaging();
                    dataPaging.meta.total = compList.Count;
                    dataPaging.meta.perpage = 10;
                    dataPaging.meta.page = 1;

                }

            }

            return dataPaging;
        }

        // GET api/values
    
        [Route("List2")]
        public DataPaging<MS_Company> List2(HttpRequestMessage v)
        {
            DataPaging<MS_Company> dataPaging = new DataPaging<MS_Company>();
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
            List<MS_Company> compList = null;

            using (OASEntities _ent = new OASEntities())
            {

                int totalRow = _ent.Database.SqlQuery<int>(@"  select  count(*) totalRow  from MS_Company where compName like '%" + search + "%' or compCode like '%" + search + "%' ").Single();

                compList = _ent.MS_Company.SqlQuery(@" select top " + perpage + " * from ( Select *,ROW_NUMBER() OVER(ORDER BY " +
                    orderField + " " + orderby + ") r from MS_Company where compName like '%" + search + "%' or compCode like '%" + search + "%'"
                   + " ) company where r > " + startRow + " "
                    ).ToList();

                dataPaging.data = compList;

                dataPaging.meta.total = totalRow;

                dataPaging.meta.pages = Decimal.ToInt32(dataPaging.meta.total / dataPaging.meta.perpage);

            }



            return dataPaging;
        }
        [Route("Insert")]
        public MS_Company Insert(MS_Company comp)
        {
            using (OASEntities _ent = new OASEntities())
            {
                _ent.MS_Company.Add(comp);
                _ent.SaveChanges();
                return comp;
            }
        }


        public MS_Company Put(string id, MS_Company comp)
        {
            using (OASEntities _ent = new OASEntities())
            {
                MS_Company compExits = _ent.MS_Company.Find(id);

                if (compExits == null) throw new Exception("id:" + id + " not found ");

                compExits.CompName = comp.CompName;
                compExits.UpdateUser = comp.UpdateUser;
                compExits.UpdateDatetime = DateTime.Now;
                _ent.SaveChanges();
                return comp;
            }


        }

        public void Delete(string id)
        {
            using (OASEntities _ent = new OASEntities())
            {
                MS_Company comp = _ent.MS_Company.Find(id);
                _ent.MS_Company.Remove(comp);
                _ent.SaveChanges();
            }
        }
    }
}
