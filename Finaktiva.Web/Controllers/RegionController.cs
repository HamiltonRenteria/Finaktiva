using Model.Entidad;
using Model.Neg;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Finaktiva.Web.Controllers
{
    public class RegionController : Controller
    {
        private readonly RegionNeg _regionNeg = new RegionNeg();

        // GET: Region
        public ActionResult Index()
        {
            List<Region> regions = _regionNeg.ConsultarRegiones();
            return View(regions);
        }

        // GET: Region/Details/5
        public ActionResult Details(int id)
        {
            Region region = _regionNeg.ConsultarRegion(id);
            return View(region);
        }

        // GET: Region/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Region/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Region region = new Region { CodigoRegion = Convert.ToInt32(collection["CodigoRegion"]), NombreRegion = collection["NombreRegion"].ToString() };

                _regionNeg.CrearRegion(region);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Region/Edit/5
        public ActionResult Edit(int id)
        {
            Region region = _regionNeg.ConsultarRegion(id);
            return View(region);
        }

        // POST: Region/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Region region = new Region
                {
                    CodigoRegion = Convert.ToInt32(collection["CodigoRegion"]),
                    NombreRegion = collection["NombreRegion"].ToString()
                };

                _regionNeg.ActualizarRegion(id, region);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditRegion(int id)
        {
            var tablaRegions = new RegionCiudad();
            var listRegionCiudads = new List<RegionCiudad>();

            var region = _regionNeg.ConsultarRegionCiudades(id);

            ViewBag.Rows = region.Count;

            foreach (var item in region)
            {
                listRegionCiudads.Add(new RegionCiudad
                {
                    CodigoRegion = item.CodigoRegion,
                    NombreRegion = item.NombreRegion,
                    CodigoCiudad = item.CodigoCiudad,
                    NombreCiudad = item.NombreCiudad,
                    Estado = item.Estado
                });

                tablaRegions = new RegionCiudad(item.CodigoRegion, item.NombreRegion, item.CodigoCiudad, item.NombreCiudad, item.Estado);
            }

            ViewBag.RegionCiudades = listRegionCiudads;

            return View(tablaRegions);
        }

        // POST: Region/Edit/5
        [HttpPost]
        public ActionResult EditRegion(int id, FormCollection collection)
        {
            List<Ciudad> ciudads = new List<Ciudad>();

            try
            {
                // TODO: Add update logic here
                Region region = new Region
                {
                    CodigoRegion = Convert.ToInt32(collection["CodigoRegion"]),
                    NombreRegion = collection["NombreRegion"].ToString()
                };

                ciudads.Add(new Ciudad
                {
                    CodigoCiudad = Convert.ToInt32(collection["CodigoRegion"]),
                    NombreCiudad = collection["NombreRegion"].ToString(),
                    Estado = collection["NombreRegion"].ToString()
                });

                _regionNeg.ActualizarRegionCiudades(id, region, ciudads);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Region/Delete/5
        public ActionResult Delete(int id)
        {
            var regions = _regionNeg.ConsultarRegion(id);

            return View(regions);
        }

        // POST: Region/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _regionNeg.EliminarRegion(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
