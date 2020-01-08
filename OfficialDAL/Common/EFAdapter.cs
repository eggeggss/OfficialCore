using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OfficialDAL.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficialDAL.Common
{
    public class EFAdapter
    {
        public string Location;

        private ILogger<EFAdapter> _logger;
        public String DbString
        {
            get
            {
                if (Location.Equals("Test"))
                {
                    return "Data Source=192.168.0.106;Initial Catalog=MIRLE_WEB;User ID=sa;Password=Password!";
                }
                else
                {
                    return "Data Source=192.168.0.106;Initial Catalog=MIRLE_WEB;User ID=sa;Password=Password!";
                }
            }
        }

        public Profile Profile { get; set; }
        public EFAdapter(ILogger<EFAdapter> logger, IOptionsSnapshot<Profile> profile)
        {
            //_location = Location;
            _logger = logger;
            Profile = profile.Value;
            this.Location = Profile.Site;

        }

        public T Catch<T>(Func<T> func)
        {
            try
            {
                return func.Invoke();
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("EF adapter catch Message:{ex.Message}", ex.Message);
                //System.Diagnostics.EventLog.WriteEntry("DBDev", $"EF adapter catch Message:{ex.Message}", System.Diagnostics.EventLogEntryType.Error);

                throw new Exception("db fail : " + ex.Message);
            }
        }
    }
}
