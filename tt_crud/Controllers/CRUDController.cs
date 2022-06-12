using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using tt_crud.Models;

namespace tt_crud.Controllers
{
    public class CRUDController : Controller
    {

        public ActionResult SelectTT()
        {
            var DownloadString = Utility.DownloadString("Select");
            var rs = JsonConvert.DeserializeObject<List<master_model>>(DownloadString);
            return View(rs.ToList());
        }




        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(master_model model)
        {

            var input = new List<master_model>();
            input.Add(new master_model
            {
                MT_HN = model.MT_HN,
                MT_Fname = model.MT_Fname,
                MT_Lname = model.MT_Lname,
                MT_Phone = model.MT_Phone,
                MT_Email = model.MT_Email,
            });


            var UploadString = Utility.UploadString(input, "InsertTT");
            var rs = JsonConvert.DeserializeObject<response_model>(UploadString);
            if (rs.status == true)
            {
                ViewBag.Message = "Created Successful";
            }
            else
            {
                ViewBag.Message = rs.mes;
                return View();
            }

           // return View();

            return RedirectToAction("SelectTT");

        }


        [HttpGet]
        public ActionResult Edit(int MT_ID = 0)
        {
            if (MT_ID <= 0 )
            {
                return RedirectToAction("SelectTT");
            }

            var DownloadString = Utility.DownloadString("SelectGetId/" + MT_ID.ToString());
            var rs = JsonConvert.DeserializeObject<master_model>(DownloadString);
            //ViewBag.MessageEdit = rs.mes;
            return View(rs);
        }

        [HttpPost]
        public ActionResult Edit(master_model model)
        {
            var input = new
            {
                MT_ID = model.MT_ID,
                MT_HN = model.MT_HN,
                MT_Fname = model.MT_Fname,
                MT_Lname = model.MT_Lname,
                MT_Phone = model.MT_Phone,
                MT_Email = model.MT_Email,
            };

            var UploadString = Utility.UploadString(input, "updateTT");
            var rs = JsonConvert.DeserializeObject<response_model>(UploadString);
            if (rs.status == true)
            {
                return RedirectToAction("SelectTT");
            }

            return View();
        }


        //public ActionResult Delete(int MT_ID)
        //{
        //    string sURL = "http://localhost/TT_api/api/deleteTT/" + MT_ID.ToString();

        //    WebRequest request = WebRequest.Create(sURL);
        //    request.Method = "DELETE";

        //    return RedirectToAction("SelectTT");
        //}


        public ActionResult Delete(int MT_ID)
        {
            string message = "success";
            try
            {
                string sURL = "http://localhost/TT_api/api/deleteTT/" + MT_ID.ToString();
                WebRequest request = WebRequest.Create(sURL);
                request.Method = "DELETE";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            }
            catch (Exception ex)
            {
                message = ex.Message;
               // throw;
            }
          

            return Json(new { message = message });
        }

    }
}