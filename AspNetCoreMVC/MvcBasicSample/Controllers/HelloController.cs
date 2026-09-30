using Microsoft.AspNetCore.Mvc;
using MvcBasicSample.Models;

namespace MvcBasicSample.Controllers;

//URLのHelloに対応する要求を受け取るController
public class HelloController : Controller {


    // ../Hello/Indexで呼び出されるAction
    public IActionResult Index() {
        var products = new List<Product> {

        new Product {
            Name = "ハンバーガー", //商品名
            Price = 500            //価格
        },

        new Product {
            Name = "紅茶", 
            Price = 450        
        }
      };
        return View(products);
    }
}

