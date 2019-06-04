
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using vopen_api.Models;

namespace vopen_api.Repositories
{
    public class ConferencesRepository: IRepository<Conference>
    {
        private IHostingEnvironment hostingEnvironment;

        public ConferencesRepository(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public Conference GetById(string id)
        {
            var result = this.GetAll();
            return result.FirstOrDefault(item => item.Id == id);
        }

        public ICollection<Conference> GetAll()
        {
            using (StreamReader file = File.OpenText(Path.Combine(hostingEnvironment.WebRootPath, "dummyData.json")))
            {
                string json = file.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<Conference>> (json);
                return items;
            }
        }

        public void Create(Conference entity)
        {

        }

        public void Update(Conference entity)
        {

        }

        public void Delete(Conference entity)
        {

        }

    }
}
