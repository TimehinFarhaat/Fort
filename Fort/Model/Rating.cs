using Fort.Contract;

namespace Fort.Model
{
    public class Rating:base_Entity
    {
       
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
        public int Value { get; set; }
    }
}
