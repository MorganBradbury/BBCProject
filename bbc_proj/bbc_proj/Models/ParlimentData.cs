using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace bbc_proj.Models
{
    public class ParlimentData
    {
        //MP Name
        public string Name { get; set; }

        //MP Surname
        public string Surname { get; set; }

        //MP Party Name
        public string PartyName { get; set; }

        //Unique Field // Primary Key.
        public string memberId { get; set; }
    }


    public class DataHelpers
    {
        public static List<ParlimentData> parlimentDataFromXML()
        {
            //This is the link which the method below will use to fetch the data and return a list.
            string dataLink = "http://data.parliament.uk/membersdataplatform/services/mnis/members/query/House=Commons%7CIsEligible=true";

            //Generate an object to loop through the XML which is returned from API above.
            XmlDocument doc = new XmlDocument();

            //Load the data using API.
            doc.Load(dataLink);

            // Initialise the list. 
            List<ParlimentData> dtMembers = new List<ParlimentData>();
            foreach (XmlNode parent in doc.DocumentElement)
            {                   
                // Works out first name of MP
                string name_parse = parent.ChildNodes[0].InnerText;
                int index_fn = name_parse.LastIndexOf(" ");
                if (index_fn > 0)
                {
                    name_parse = name_parse.Substring(0, index_fn);
                }

                // Works out surname of MP
                string surname_parse = parent.ChildNodes[1].InnerText;
                int index_sn = surname_parse.IndexOf(" ");
                if (index_sn > 0)
                    surname_parse = surname_parse.Substring(0, index_sn);

                dtMembers.Add(new ParlimentData
                {
                    // Name = MP's first name.
                    // Surname = MP's last name
                    // PartyName = MP's party name.
                    // MemberId = Unique ID for MP.
                    memberId = parent.Attributes["Member_Id"].InnerText,
                    Name = name_parse,
                    Surname = surname_parse.Replace(",", ""),
                    PartyName = parent.ChildNodes[7].InnerText
                });
                
            }

            // Loop through the data and append the required data to a list to be returned to the view.

            // Returns data list to the controller / view.
            return dtMembers;
        }

    }

    

}