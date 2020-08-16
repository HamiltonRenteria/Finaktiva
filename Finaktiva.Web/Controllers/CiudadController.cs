using Model.Entidad;
using Model.Neg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finaktiva.Web.Controllers
{
    public class CiudadController : Controller
    {
        private CiudadNeg _ciudadNeg = new CiudadNeg();

        // GET: Ciudad
        public ActionResult Index()
        {
            var ciudades = _ciudadNeg.ConsultarCiudades();
            return View(ciudades);
        }

        // GET: Ciudad/Details/5
        public ActionResult Details(int id)
        {
            var ciudad = _ciudadNeg.ConsultarCiudad(id);
            return View(ciudad);
        }

        // GET: Ciudad/Create
        public ActionResult Create()
        {
            var listaEstados = new List<string>();

            listaEstados.Add("Activo");
            listaEstados.Add("Inactivo");

            ViewBag.ListaEstados = listaEstados;

            return View();
        }

        // POST: Ciudad/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Ciudad ciudad = new Ciudad
                {
                    CodigoCiudad = Convert.ToInt32(collection["CodigoCiudad"])
                    , NombreCiudad = collection["NombreCiudad"].ToString()
                    , Estado = collection["Estado"]
                };

                _ciudadNeg.CrearCiudad(ciudad);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ciudad/Edit/5
        public ActionResult Edit(int id)
        {
            var ciudad = _ciudadNeg.ConsultarCiudad(id);
            var listaEstados = new List<string>();

            listaEstados.Add("Activo");
            listaEstados.Add("Inactivo");

            ViewBag.ListaEstados = listaEstados;

            return View(ciudad);
        }

        // POST: Ciudad/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Ciudad ciudad = new Ciudad { CodigoCiudad = Convert.ToInt32(collection["CodigoCiudad"]), NombreCiudad = collection["NombreCiudad"].ToString(), Estado = collection["Estado"] };

                _ciudadNeg.ActualizarCiudad(id, ciudad);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ciudad/Delete/5
        public ActionResult Delete(int id)
        {
            var ciudad = _ciudadNeg.ConsultarCiudad(id);
            var listaEstados = new List<string>();

            listaEstados.Add("Activo");
            listaEstados.Add("Inactivo");

            ViewBag.ListaEstados = listaEstados;

            return View(ciudad);
        }

        // POST: Ciudad/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _ciudadNeg.EliminarCiudad(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
