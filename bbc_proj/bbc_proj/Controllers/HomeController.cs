using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using bbc_proj.Models;

namespace bbc_proj.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // The model receives a list of information which the View will process to provide a list of MP data.
            var Model = DataHelpers.parlimentDataFromXML();
            return View(Model);
        }

        public JsonResult returnCommittees()
        {
            string CommitteesJson = null;
            //This is the link which the method below will use to fetch the data and return a list.
            string dataLink = "http://data.parliament.uk/membersdataplatform/xml/Committees.xml";

            //Generate an object to loop through the XML which is returned from API above.
            XmlDocument doc = new XmlDocument();

            //Load the data using API.
            doc.Load(dataLink);
            foreach (XmlNode parent in doc.DocumentElement)
            {
                foreach (XmlNode members in parent.ChildNodes)
                {
                    if (members.Name == "Committees")
                    {
                        foreach (XmlNode constituencies in members.ChildNodes)
                        {
                            CommitteesJson += "<li>Name: " + constituencies.ChildNodes[0].InnerText + "</li>" +
                            "<li>Start Date: " + constituencies.ChildNodes[1].InnerText + "</li>" +
                            "<li>End Date : " + constituencies.ChildNodes[2].InnerText + "</li>";
                        }
                    }
                }

            }

            // Returns data list to the controller / view.
            return Json(CommitteesJson, JsonRequestBehavior.AllowGet);
        }


        public JsonResult returnConstituencies()
        {
            string ConstituenciesJson = null;
            //This is the link which the method below will use to fetch the data and return a list.
            string dataLink = "http://data.parliament.uk/membersdataplatform/xml/Constituencies.xml";

            //Generate an object to loop through the XML which is returned from API above.
            XmlDocument doc = new XmlDocument();

            //Load the data using API.
            doc.Load(dataLink);
            foreach (XmlNode parent in doc.DocumentElement)
            {
                foreach (XmlNode members in parent.ChildNodes)
                {
                    if (members.Name == "Constituencies")
                    {
                        foreach (XmlNode constituencies in members.ChildNodes)
                        {
                            ConstituenciesJson += "<li>Name: " + constituencies.ChildNodes[0].InnerText  + "</li>" +
                            "<li>Start Date: " + constituencies.ChildNodes[1].InnerText + "</li>" +
                            "<li>End Date : " + constituencies.ChildNodes[2].InnerText + "</li>";
                        }
                    }
                }

            }

            // Returns data list to the controller / view.
            return Json(ConstituenciesJson, JsonRequestBehavior.AllowGet);
        }

        public JsonResult returnStaff()
        {
            string StaffJson = null;
            //This is the link which the method below will use to fetch the data and return a list.
            string dataLink = "http://data.parliament.uk/membersdataplatform/xml/Staff.xml";

            //Generate an object to loop through the XML which is returned from API above.
            XmlDocument doc = new XmlDocument();

            //Load the data using API.
            doc.Load(dataLink);
            foreach (XmlNode staffnode in doc.DocumentElement)
            {
                foreach(XmlNode child in staffnode.ChildNodes)
                {
                    if(child.Name == "Staffing")
                    {
                        foreach (XmlNode staff_info in child.ChildNodes)
                        {
                            StaffJson += "<li>Title: " + staff_info.ChildNodes[0].InnerText + "</li>" +
                            "<li>First Name: " + staff_info.ChildNodes[1].InnerText + "</li>" +
                            "<li>Surname: " + staff_info.ChildNodes[3].InnerText + "</li>" +
                            "<li>Note: " + staff_info.ChildNodes[4].InnerText + "</li>";
                        }
                    }
                }
            }

            // Returns data list to the controller / view.
            return Json(StaffJson, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PayloadAPI()
        {
            // process data below
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}