using SalehVMPartialView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalehVMPartialView.Controllers
{
    //4 we create controller as Home
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View(MyList.myList);
        }
        // GET: Home
        //[HttpGet]
        //we need by this way to pass the hall object not id  
        //public ActionResult PrtialIndex(Person personForPartial)
        //{
        //    //we have to sent name of patial view as View to draw this interface and the object to get info-
        //    return PartialView("_PartialPerson", personForPartial);
        //}

        //but in this way we fitch just id from "View" "Index" to return object to partial view "_PartialPerson" 

        //[HttpGet] //we use this method by get index and post index then we do not neeed to restrict this method as get /post 
        public ActionResult PrtialIndex(int id)
        {
            Person person = MyList.myList.SingleOrDefault(p => p.Id == id);
            return PartialView("_PartialPerson", person);
        }

        [HttpPost]
        public ActionResult Index(string searchTxt = "", string City = "")
        {
            if (!string.IsNullOrEmpty(searchTxt))
            {
                if (City == "city")
                {
                    return View(MyList.myList.Where(x => x.City.ToLower().Contains(searchTxt.ToLower())).OrderBy(x => x.Name));
                }
                else if (City != "city")
                {
                    return View(MyList.myList.Where(x => x.Name.ToLower().Contains(searchTxt.ToLower())).OrderBy(x => x.City));
                }
            }
            else
            {
                return View(MyList.myList);
            }
            return View("Index");
        }

        //6 create method for Create 
        [HttpGet]
        public ActionResult Create()
        {
            //7 now we need create view to get new info from user 
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person newPerson)//we need info to send as save to dtabase
        {//here we do not need new obj because it is static class then direct to memory
            //increase id in list  +1
            newPerson.Id = MyList.myList.Last().Id + 1;

            //add to static list
            MyList.myList.Add(newPerson);
            /*Be carfauly do not use return view()  but use RedirectToAction
             * to go to another action then it will draw view efter that */
            return RedirectToAction("Index");
        }
        /*in edit we need id as input then we change and save by view then we need to know this object to save changes 
         * that will be by collection "Person person = MyList.myList.SingleOrDefault(x => x.Id == id);" and return 
         * this object to display this object by view to change it if we need */
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //i is to search inside list avoiding null exception with "SingleOrDefault"
            //Person persom = MyList.myList.Find(x => x.Id == id);
            Person person = MyList.myList.SingleOrDefault(x => x.Id == id);
            return View(person);/*return reference to display in Edit view but 
            we need Edit Post To RedirectionToAction "Index"*/
        }
        /*we need to save those changes efter editing that will be by this collection "MyList.myList.Add(editPerson);"
         * then return "RedirectToAction("Index")"*/
        [HttpPost]
        public ActionResult Edit(Person editPerson)
        {
            //MyList.myList.Add(editPerson);//save in static list 
            //we have up editPerson as input then we need to get old one to assign changes to him by this collection down 
            Person oldPerson = MyList.myList.SingleOrDefault(x => x.Id == editPerson.Id);//we get the old object 
            //now we will assing new info to the old one by this down
            oldPerson.Name = editPerson.Name;//assign to old this new 
            oldPerson.City = editPerson.Name;

            return RedirectToAction("Index");// it is important return RedirectToAction("Index")
        }

        //we need info as input id of object to display it in view details then return to index by ActinLink that is in "Details" View 
        [HttpGet]
        public ActionResult Details(int id)
        {
            Person detPerson = new Person();

            detPerson = MyList.myList.SingleOrDefault(x => x.Id == id);

            return View(detPerson);
        }
        //we need view to display this object then we press delete then we have action link as confirm in veiw to call "post delete method" 
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Person detPerson = new Person();

            detPerson = MyList.myList.SingleOrDefault(x => x.Id == id);

            return View(detPerson);
        }
        /*we need to change the name of "delete method" to 
         * avoid OverLoading because it has same "input int id"*/
        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            Person delPerson = new Person();

            delPerson = MyList.myList.SingleOrDefault(x => x.Id == id);
            //We remove object
            MyList.myList.Remove(delPerson);
            return RedirectToAction("Index");
        }
        //we create input type of string for input Element as <input type="CheckBox" name="City" value="city"
        public ActionResult Search(string src, string City)
        {
            Person SrcPerson = new Person();
            if (City == "city")
            {
                //SrcPerson = MyList.myList.Where( x => x.Id == src );
            }
            return View();
        }
    }
}
