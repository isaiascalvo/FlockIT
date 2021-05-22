using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenTecnico.Models
{
    public class Response<T>
    {
        public bool IsSuccessfully { get; set; }
        public T Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
