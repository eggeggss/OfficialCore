using OfficialDAL.Common;
using OfficialDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OfficialDAL.DAL
{
    public class AdminUserDAL
    {
        public string Location { set; get; }
        private EFAdapter _adapter;

        public MIRLE_WEBContext entity { get; set; }

        public AdminUserDAL(EFAdapter adapter, MIRLE_WEBContext _entity)
        {
            Location = adapter.Location;
            _adapter = adapter;
            entity = _entity;
        }
        public AdminNew GetEmp(string emp_no)
        {
            using (entity)
            {
                Func<AdminNew> func = new Func<AdminNew>(() => {

                    //entity._optionsBuilder.UseSqlServer(Location);

                    var result = entity.AdminNew.Where(e => e.UId == emp_no && e.StatVoid == 0).ToList().FirstOrDefault();
                    return result;

                });

                return _adapter.Catch<AdminNew>(func);
            }
        }



        public AdminNew GetEmpByEname(string emp_name)
        {
            using (entity)
            {
                Func<AdminNew> func = new Func<AdminNew>(() => {

                    //entity._optionsBuilder.UseSqlServer(Location);

                    var result = entity.AdminNew.Where(e => e.UName == emp_name && e.StatVoid == 0).ToList().FirstOrDefault();
                    return result;

                });

                return _adapter.Catch<AdminNew>(func);
            }
        }

        public Task<bool> InsertEmp(AdminNew user)
        {
            using (entity)
            {
                Func<Task<bool>> func = new Func<Task<bool>>(async () => {

                    //entity._optionsBuilder.UseSqlServer(Location);

                    entity.Entry(user).State = EntityState.Added;

                    await entity.SaveChangesAsync();

                    return true;
                });

                return _adapter.Catch<Task<bool>>(func);
            }
        }

        public Task<bool> UpdateEmp(AdminNew user)
        {
            using (entity)
            {
                Func<Task<bool>> func = new Func<Task<bool>>(async () => {

                    //entity._optionsBuilder.UseSqlServer(Location);

                    entity.Entry(user).State = EntityState.Modified;

                    await entity.SaveChangesAsync();

                    return true;
                });

                return _adapter.Catch<Task<bool>>(func);
            }
        }

        public Task<bool> DeleteEmp(string uid)
        {
            using (entity)
            {
                Func<Task<bool>> func = new Func<Task<bool>>(async () => {

                    //entity._optionsBuilder.UseSqlServer(Location);

                    AdminNew admin = entity.AdminNew.Where(e => e.UId.Equals(uid) && e.StatVoid == 0).ToList().FirstOrDefault();

                    if (admin != null)
                    {
                        admin.StatVoid = 1;
                        admin.DtUpdate = DateTime.Now;
                        entity.Entry(admin).State = EntityState.Modified;
                        await entity.SaveChangesAsync();
                    }

                    return true;
                });

                return _adapter.Catch<Task<bool>>(func);
            }
        }

    }
}
