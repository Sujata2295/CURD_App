using Microsoft.AspNetCore.Mvc;
using State_New.Models;

namespace State_New.Controllers
{
    public class StateController : Controller
    {
        StateDataAccesslayer stateDataAccesslayer = new StateDataAccesslayer();
        public IActionResult Index()
        {
            return View(stateDataAccesslayer.GetAllState());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StateModel stateModel)
        {
            if(stateModel != null)
            {
                stateDataAccesslayer.insertStateModel(stateModel);
                TempData["State Success"] = "Record Insert Succesfully";
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            StateModel stateModel= stateDataAccesslayer.GetStateById(id);
            return View(stateModel);
        }
        [HttpPost]
        public IActionResult Edit(StateModel stateModel) 
        {
            if(stateModel != null)
            {
                stateDataAccesslayer.updateStateModel(stateModel);
                TempData["Update Succes"] = "Update successfully";
            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            if (id != 0)
            {
                StateModel stateModel = stateDataAccesslayer.GetStateById(id);
                if (stateModel != null)
                {
                    return View(stateModel);
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) 
        {
            stateDataAccesslayer.deleteStateModel(id);
            return RedirectToAction("Index");
        }
        
        
    }
}
