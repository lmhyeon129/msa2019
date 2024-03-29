using System;

namespace donation_MERCHANT.Models
{
    public class Product
    {
        public string ProdId { get; set; }
        public string UserSeq { get; set; }
        public BizType BizType { get; set; }
        public State ProdState { get; set; }
        public int ProdAmt { get; set; }
        public DateTime RegDate { get; set; }
        public DateTime EditDate { get; set; }
    }
    public enum State
    {
        PREPARED,
        RESERVATED,
        DELIVERED
    }
    public enum BizType
    {
        FODD,
        BEAVERAGE,
        FURNITURE,
        DRESS
    }
}