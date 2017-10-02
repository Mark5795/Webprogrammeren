using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;
using MvcMusicStore.Repositories;

namespace MvcMusicStore.Controllers
{
    public class StoreManagerController : Controller
    {
        //private MusicStoreDB db = new MusicStoreDB();

        ////GET: StoreManager
        //public ActionResult Index()
        //{
        //    var albums = db.Albums.Include(a => a.Artist).Include(a => a.Genre);
        //    return View(albums.ToList());
        //}

        private IAlbumRepository albumRepository = new AlbumRepository();

        public ActionResult Index()
        {
            IEnumerable<Album> allAlbums = albumRepository.GetAllAlbums();
            return View(allAlbums);
        }

        // GET: StoreManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = albumRepository.GetAlbum((int)id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: StoreManager/Create
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(albumRepository.Artists, "ArtistId", "Name");
            ViewBag.GenreId = new SelectList(albumRepository.Genres, "GenreId", "Name");
            return View();
        }

        // POST: StoreManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] Album album)
        {
            if (ModelState.IsValid)
            {
                albumRepository.AddAlbum(album);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(albumRepository.Artists, "ArtistId", "Name", album.ArtistId);
            ViewBag.GenreId = new SelectList(albumRepository.Genres, "GenreId", "Name", album.GenreId);
            return View(album);
        }

        // GET: StoreManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = albumRepository.GetAlbum((int)id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(albumRepository.Artists, "ArtistId", "Name", album.ArtistId);
            ViewBag.GenreId = new SelectList(albumRepository.Genres, "GenreId", "Name", album.GenreId);
            return View(album);
        }

        // POST: StoreManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] Album album)
        {
            if (ModelState.IsValid)
            {
                albumRepository.EditAlbum(album);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistId = new SelectList(albumRepository.Artists, "ArtistId", "Name", album.ArtistId);
            ViewBag.GenreId = new SelectList(albumRepository.Genres, "GenreId", "Name", album.GenreId);
            return View(album);
        }

        // GET: StoreManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = albumRepository.GetAlbum((int)id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = albumRepository.GetAlbum((int)id);
            albumRepository.RemoveAlbum(id);
            //db.Albums.Remove(album);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                albumRepository.Dispose((bool) disposing);
            }
            base.Dispose(disposing);
        }
    }
}
