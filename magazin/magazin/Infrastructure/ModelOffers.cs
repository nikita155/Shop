using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace magazin
{
   public partial class MainPage
    {
        //Класс для хранения: <categoryId type="...">...</categoryId>
        public class Category
        {
            public string categoryType { get; set; }
            public string categoryId { get; set; }
        }

        //Класс для хранения: <hall plan="...">...</hall>
        class Hall
        {
            public string plan { get; set; }
            public string hall { get; set; }

        }

        //Базовый класс
        class Offer
        {
            public string id { get; set; }
            public string url { get; set; }
            public string price { get; set; }
            public string currencyId { get; set; }
            public Category category { get; set; }
            public string picture { get; set; }
            public string delivery { get; set; }
        }

        class Tour : Offer
        {
            public static string Type { get; } = "tour";
            public string worldRegion { get; set; }
            public string country { get; set; }
            public string artist { get; set; }
            public string region { get; set; }
            public string days { get; set; }
            public string dataTour { get; set; }
            public string name { get; set; }
            public string hotel_stars { get; set; }
            public string room { get; set; }
            public string meal { get; set; }
            public string included { get; set; }
            public string transport { get; set; }
            public string description { get; set; }

        }

        class EventTicket : Offer
        {
            public static string Type { get; } = "event-ticket";
            public string name { get; set; }
            public string place { get; set; }
            public Hall hall { get; set; }
            public string hall_part { get; set; }
            public string date { get; set; }
            public string is_premiere { get; set; }
            public string is_kids { get; set; }
            public string description { get; set; }
        }

        class ArtistTitle : Offer
        {
            public static string Type { get; } = "artist.title";
            public string artist { get; set; }
            public string title { get; set; }
            public string year { get; set; }
            public string media { get; set; }
            public string description { get; set; }
            public string starring { get; set; }
            public string director { get; set; }
            public string originalName { get; set; }
            public string country { get; set; }

        }

        class VendorModel : Offer
        {
            public static string Type { get; } = "vendor.model";
            public string local_delivery_cost { get; set; }
            public string typePrefix { get; set; }
            public string vendor { get; set; }
            public string vendorCode { get; set; }
            public string model { get; set; }
            public string description { get; set; }
            public string manufacturer_warranty { get; set; }
            public string country_of_origin { get; set; }
        }

        class Audiobook : Offer
        {
            public static string Type { get; } = "audiobook";
            public string ISBN { get; set; }
            public string language { get; set; }
            public string performed_by { get; set; }
            public string performance_type { get; set; }
            public string storage { get; set; }
            public string format { get; set; }
            public string recording_length { get; set; }
            public string description { get; set; }
            public string downloadable { get; set; }
            public string author { get; set; }
            public string name { get; set; }
            public string publisher { get; set; }
            public string year { get; set; }
        }

        class Book : Offer
        {
            public static string Type { get; } = "book";
            public string local_delivery_cost { get; set; }
            public string series { get; set; }
            public string ISBN { get; set; }
            public string volume { get; set; }
            public string part { get; set; }
            public string language { get; set; }
            public string binding { get; set; }
            public string page_extent { get; set; }
            public string description { get; set; }
            public string downloadable { get; set; }
            public string author { get; set; }
            public string name { get; set; }
            public string publisher { get; set; }
            public string year { get; set; }
        }
    }
}
