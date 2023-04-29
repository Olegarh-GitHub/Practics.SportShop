using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Practics.SportShop.Models.Inputs;

public enum ProductsDiscountFilterInput
{
    [Display(Name = "Все диапазоны")]
    All,
    
    [Display(Name = "0-9,99%")]
    ZeroToTen,
    
    [Display(Name = "10-14,99%")]
    TenToFifteen,
    
    [Display(Name = "Более 15%")]
    FromFifteen,
}