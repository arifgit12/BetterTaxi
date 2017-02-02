using AutoMapper;
using BetterTaxi.Data;
using BetterTaxi.Models;
using BetterTaxi.Web.WebApiViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BetterTaxi.Web.WebAPI
{
    [Authorize]
    [RoutePrefix("api/Photos")]
    public class PhotosController : BaseApiController, IRESTController<PhotoDTO>
    {
        public PhotosController(ITaxiData data)
           : base(data)
        {

        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var user = GetUser();
            var photo = this.Data.Photos.SearchFor(p => p.Id == id).FirstOrDefault();
            if (photo == null)
            {
                return NotFound();
            }


            if (photo.Id != user.Photo.Id)
            {
                return BadRequest("Not your photo!");
            }

            user.Photo = null;

            this.Data.Photos.Delete(photo);
            this.Data.Photos.SaveChanges();
            return Ok(id);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var user = GetUser();

            if(user.Photo == null)
            {
                return NotFound();
            }

            var photo = this.Data.Photos
               .All()
               .Where(p => p.Id == user.Photo.Id).FirstOrDefault();

            if (photo == null)
            {
                return NotFound();
            }

            var photoDTO = new PhotoDTO()
            {
                Id = photo.Id,
                FileExtension = photo.FileExtension,
                Content = GetString(photo.Content)
            };

            return Ok(photoDTO);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var photo = this.Data.Photos
               .All()
               .Where(p => p.Id == id).FirstOrDefault();

            if (photo == null)
            {
                return NotFound();
            }
            var photoDTO = new PhotoDTO()
            {
                Id = photo.Id,
                FileExtension = photo.FileExtension,
                Content = GetString(photo.Content)
            };

            return Ok(photoDTO);
        }

        [NonAction]
        public IHttpActionResult GetPaged(int page)
        {
            return BadRequest();
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] PhotoDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model state!");
            }

            //var photo = Mapper.Map<Photo>(model);
            var photo = new Photo()
            {
                FileExtension = model.FileExtension,
                Content = GetBytes(model.Content)
            };
            this.Data.Photos.Add(photo);

            var user = GetUser();
            user.Photo = photo;
            this.Data.SaveChanges();
            return Ok(photo.Id);
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody] PhotoDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model state!");
            }

            var photo = this.Data.Photos.SearchFor(p => p.Id == model.Id).FirstOrDefault();

            if (photo == null) return BadRequest("No photo to update!");

            var user = GetUser();
            if (user.Photo != null && user.Photo.Id != photo.Id) return BadRequest("Not your photo!");

            photo = Mapper.Map<Photo>(model);

            this.Data.Photos.Update(photo);
            this.Data.SaveChanges();

            return Ok(photo.Id);
        }

        #region Helpers
        [NonAction]
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        [NonAction]
        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
        #endregion

    }
}