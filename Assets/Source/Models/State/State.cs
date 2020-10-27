using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Models
{
    public abstract class BaseState
    {
        public abstract BaseState Update(PersonModel person);
    }
}
