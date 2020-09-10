using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skclusive.Core.Component;
using Skclusive.Transition.Component;
using Skclusive.Script.DomHelpers;


namespace pnl.Models
{
    public class ToggleMe
    {
        public string name { get; set; }
        internal bool isToggled { set; get; } = true;
        internal Color color { set; get; }
        private bool Error => (new bool[] { isToggled }).Where(x => !!x).Count() != 2;
        public void HandleToggleChanged()
        {
            isToggled = !isToggled;            
        }
    }
}
