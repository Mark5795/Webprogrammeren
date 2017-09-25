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
        IEnumerable<Album> GetAllAlbums();
        Album GetAlbum(int albumId);
        void AddAlbum(Album album);
    }
}