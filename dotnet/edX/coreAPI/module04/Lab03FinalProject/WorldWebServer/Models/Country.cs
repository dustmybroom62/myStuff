/*
Code char(3) PK 
Name char(52) 
Region char(26) 
NationalFlag varchar(200)
 */

using System.ComponentModel.DataAnnotations;

namespace WorldWebServer.Models {
     public class Country {
         [Key]
         public string Code {get; set;}
         public string Name {get; set;}
        //  public string Region {get; set;}
        //  public string NationalFlag {get; set;}
     }
 }