using Mavis.Core;

namespace MyDemo.Core
{
    public class PaySystem : Entity
    {
        public PaySystem()
        {
            AddRule(new SimpleRule("Name", "Name should not be Empty!", () => string.IsNullOrEmpty(Name)));
            AddRule(new SimpleRule("PaySystemCode", "PaySystemCode should not be Empty!", () => string.IsNullOrEmpty(PaySystemCode)));
        }

        public string PaySystemCode { get; set; }

        public string Name { get; set; }
        
    }
}