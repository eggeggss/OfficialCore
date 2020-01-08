using OfficialDAL.DAL;
using OfficialDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace OfficialBLL
{
    public class VideoService
    {
        public string Location { set; get; }

       
        public VideoDAL VideoDAL
        {
            set;get;
        }

        public VideoService(VideoDAL videodal)
        {
            VideoDAL = videodal;
        }

        public IEnumerable<VideoNew> GetAll()
        {
            IEnumerable<VideoNew> result = null;
            try
            {
                return this.VideoDAL.GetAll().OrderByDescending(e => e.Uptime);

            }
            catch (Exception ex)
            {
                return result;
            }
        }


        public VideoNew Get(int num)
        {
            VideoNew result = null;
            try
            {
                return this.VideoDAL.Get(num);

            }
            catch (Exception ex)
            {
                return result;
            }
        }


        public bool Insert(VideoNew video_new)
        {
            try
            {
                return this.VideoDAL.Insert(video_new);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(VideoNew video_new)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    if (video_new.BoolCheck)
                    {
                        this.ClearAllCheck();
                    }

                    this.VideoDAL.Update(video_new);

                    scope.Complete();
                }

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int num)
        {
            try
            {
                return this.VideoDAL.Delete(num);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<VideoNew> GetFilter(string title)
        {
            try
            {
                return this.VideoDAL.GetAll().Where(e => e.Title.Contains(title));

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool ClearAllCheck()
        {
            try
            {
                foreach (var item in VideoDAL.GetAll())
                {
                    item.BoolCheck = false;
                    this.Update(item);
                }

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}
