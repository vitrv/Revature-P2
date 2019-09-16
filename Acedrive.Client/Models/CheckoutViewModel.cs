using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Acedrive.Client.Models {
  public class CheckoutViewModel {
    [Required]
    public string CardType { get; set; }

    [Required]
    public string CardNumber { get; set; }

    [Required]
    public string NameOnCard { get; set; }

    [Required]
    public string SecurityCode { get; set; }

    [Required]
    public string BillingAddress { get; set; }

    [Required]
    public string BillingCity { get; set; }

    [Required]
    public string BillingState { get; set; }

    [Required]
    public string BillingZipCode { get; set; }
  }
}