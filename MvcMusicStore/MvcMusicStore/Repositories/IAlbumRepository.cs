using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Repositories;
using MvcMusicStore.Models;

namespace MvcMusicStore.Repositories
{
    interface IAlbumRepository
    {
        IEnumerable<Artist> Artists { get; }
        IEnumerable<Genre> Genres { get; }

        IEnumerable<Album> GetAllAlbums();
        Album GetAlbum(int albumId);
        void AddAlbum(Album album);
        void RemoveAlbum(int albumId);
        void Dispose(bool disposing);
        void EditAlbum(Album album);
    }
}