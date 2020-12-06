using System;
using System.Collections.Generic;
using System.Text;

namespace WebDev.Services.Entities
{
    public class ResponseCreatedDto
    {

        public int id { get; set; }

        private ResponseCreatedDto()
        {

        }

        public static ResponseCreatedDto Build(int id)
        {
            return new ResponseCreatedDto
            {
                id = id
            };
        }

    }
}
