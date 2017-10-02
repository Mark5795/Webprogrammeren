using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcMusicStore.Models;
using System.Data.Entity;

namespace MvcMusicStore.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private MusicStoreDB db = new MusicStoreDB();

        public IEnumerable<Artist> Artists { get { return db.Artists; } }
        public IEnumerable<Genre> Genres { get { return db.Genres; } }

        public IEnumerable<Album> GetAllAlbums()
        {
            IEnumerable<Album> albums = db.Albums.Include(a => a.Artist).Include(a => a.Genre);
            return albums;
        }

        public Album GetAlbum(int albumId)
        {
            Album album = db.Albums.Find(albumId);
            return album;
        }

        public void AddAlbum(Album album)
        {
            db.Albums.Add(album);
            db.SaveChanges();
        }

        public void RemoveAlbum(int albumId)
        {
            Album album = db.Albums.Find(albumId);
            db.Albums.Remove(album);
            db.SaveChanges();
        }
        
        public void EditAlbum(Album album)
        {
            db.Entry(album).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}