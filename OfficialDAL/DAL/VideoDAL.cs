using OfficialDAL.Common;
using OfficialDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using static IOfficialCommon.Common;




namespace OfficialDAL.DAL
{
    public class VideoDAL
    {
        public string Location { set; get; }
        private EFAdapter _adapter;
        private MIRLE_WEBContext _entity;


        public VideoDAL(EFAdapter adapter,
            MIRLE_WEBContext entity)
        {
            Location = adapter.Location;
            _adapter = adapter;
            _entity = entity;
        }


        public IEnumerable<VideoNew> GetAll()
        {
            
            {
                Func<IEnumerable<VideoNew>> func = new Func<IEnumerable<VideoNew>>(() =>
                {

                    var result = _entity.VideoNew.Where(e => e.StatVoid == 0)
                    .ToList();
                    return result;

                    //var result = _entity.VideoNew.Where(e => e.StatVoid == 0)
                    //.Select(e =>  new VideoNew { 
                    //    Num=e.Num,
                    //    CreateBy=e.CreateBy,
                    //    Demo=e.Demo,
                    //    DtCreate=e.DtCreate,
                    //    DtUpdate=e.DtUpdate,
                    //    Title=e.Title,
                    //    UpdateBy=e.UpdateBy,
                    //    Uptime=e.Uptime,
                    //    Url=e.Url,
                    //    StatVoid=e.StatVoid}).ToList();
                    //return result;

                });

                return _adapter.Catch<IEnumerable<VideoNew>>(func);
            }
        }

        public VideoNew Get(int num)
        {
            
            {
                Func<VideoNew> func = new Func<VideoNew>(() =>
                {

                     
                    var result = _entity.VideoNew.Where(e => e.StatVoid == 0
                    && e.Num == num).ToList().FirstOrDefault();
                    return result;

                });

                return _adapter.Catch<VideoNew>(func);
            }
        }

        public bool Insert(VideoNew VideoNew)
        {
            
            {
                Func<bool> func = new Func<bool>(() =>
                {

                     

                    _entity.Entry(VideoNew).State = EntityState.Added;

                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }
        }


        public bool Update(VideoNew VideoNew)
        {
            
            {
                Func<bool> func = new Func<bool>(() =>
                {

                     

                    VideoNew.DtUpdate = DateTime.Now;

                    _entity.Entry(VideoNew).State =EntityState.Modified;

                    _entity.SaveChanges();

                    return true;

                });

                return _adapter.Catch<bool>(func);
            }
        }



        public bool Delete(int num)
        {
            
            {
                Func<bool> func = new Func<bool>(() =>
                {

                     
                    var VideoNew = _entity.VideoNew.Where(e => e.Num == num).ToList().FirstOrDefault();
                    if (VideoNew != null)
                    {
                        VideoNew.DtUpdate = DateTime.Now;
                        VideoNew.StatVoid = 1;

                        _entity.Entry(VideoNew).State = EntityState.Modified;

                        _entity.SaveChanges();


                    }
                    return true;
                });

                return _adapter.Catch<bool>(func);
            }
        }
    }
}
