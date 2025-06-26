using NorthWind.Models;

namespace NorthwindStore.ViewModels
{
    //此為將Categories和Products兩個資料表的資料整合在一起的ViewModel
    public class VMProduct
    {
        public List<Categories>? Category { get; set; }  //導入 Categories 資料表的資料（以 List 形式儲存，Categories 來自資料庫Model）
        public List<Products>? Product { get; set; }     //導入 Products 資料表的資料（以 List 形式儲存，Products 來自資料庫Model）
        //打?表示可能為null，可打可不打
    }
}
//新增資料夾加入類別→另放ViewModel跟其他Model分開，不混淆
// ViewModel 目的是整合多個資料表資料，方便 View 一次呈現（如 Products 和 Categories）。
// ViewModel 與資料庫 Model 分離，提升維護性與彈性。
//因為View 只能接收單一 Model，使用 ViewModel 可同時取得多個資料表資料（如 @Model.Category、@Model.Product）。
// Controller 負責查詢資料並組合到 ViewModel，再傳遞給 View。
// 範例用法：在 ProductsController 的 Index 方法中，修改查詢 Products 和 Categories，整合到 VMProduct 傳給 View。



