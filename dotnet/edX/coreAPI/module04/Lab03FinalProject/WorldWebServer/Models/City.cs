/*
Table: city
Columns:
ID int(11) AI PK 
Name char(35) 
CountryCode char(3) 
District char(20) 
Population int(11)
 */

using System.ComponentModel.DataAnnotations;

namespace WorldWebServer.Models {
     public class City {
         [Key]
         public int ID {get; set;}
         public string Name {get; set;}
         public string CountryCode {get; set;}
         public string District {get; set;}
         public int Population {get; set;}
     }
 }