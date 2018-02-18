using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Collections;

namespace StdLib
{
    public class Logger
    {
        private string _logDirPath;
        private bool _isDebugLog = true; 
        private  String _logFilePath = string.Empty;
        private  FileInfo _logFile;
        public Logger(string logDirPath, bool  isDebugLog)
        {
            _logDirPath = logDirPath;
            _isDebugLog = isDebugLog;
        }
          
          

            public  void PrintConsole(String s)
            {
                if (_isDebugLog)
                {
                    System.Diagnostics.Debug.WriteLine("[Console] : " + s);
                    Debug(s);
                }

            }
            public  void Info(String s)
            {
               WriteLogEntry("[Info] : " + s);
            }
            public  void Debug(String s){
                if (_isDebugLog) {
                    WriteLogEntry("[Debug] : " + s);
                }
            }
            public void Error(String e)
            {
                WriteLogEntry("[Error] : " + e);
            }
            public void Error(Exception ex)
            {
                Error(ex.Message);
                Error(ex.StackTrace);

                if (ex.InnerException != null)
                {
                    Error(ex.InnerException);
                }
            }

            public void Error(String s,Exception ex)
            {
                Error(s);
                Error(ex);
            }


            private void SetLogFile() {
                _logFilePath = GetLogPath();
                _logFile = new FileInfo(_logFilePath);
                
                if (!System.IO.Directory.Exists(_logDirPath))
                {
                    System.IO.Directory.CreateDirectory(_logDirPath);
                }

                if (!_logFile.Exists)
                {
                    using(_logFile.Create()){};
                }

            }
             private  String GetLogPath()
             {
                 return _logDirPath + System.DateTime.Now.ToString("yyyy-MM-dd") + ".log";
             }

            private  void WriteLogEntry(string Text)
            {

                if (_logFile == null)
                      SetLogFile();
                else if (!GetLogPath().Equals(_logFilePath))
                      SetLogFile();
               
                    
                try
                {
                    using (StreamWriter logStream = _logFile.AppendText()) {
                        logStream.WriteLine("[" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + Text + "");
                    }
                 
                }
                catch
                {}
            }
    }

    //  static interface ILogImp
   // {
     //    void PrintConsole();
       //  void Info(String s);
       //  void Error(String s);
//void Error(String s, Exception ex);
   // }

}

//FileStream fs=new FileStream(Server.MapPath("myLog.txt"),FileMode.Append,FileAccess.Write);
//        StreamWriter swr = new StreamWriter(fs, true);
//        swr.Write("Enter ur Exception Here");
//        swr.Close();