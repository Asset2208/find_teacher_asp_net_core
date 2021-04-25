using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindTeacher.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FindTeacher.Models
{
    public class FilterPostViewModel
    {
        public FilterPostViewModel(List<PostCategory> categories, int? category, string name)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            categories.Insert(0, new PostCategory { Name = "Все", Id = 0 });
            Categories = new SelectList(categories, "Id", "Name", category);
            SelectedCategory = category;
            SelectedName = name;
        }
        public SelectList Categories { get; private set; } // список компаний
        public int? SelectedCategory { get; private set; }   // выбранная компания
        public string SelectedName { get; private set; }    // введенное имя
    }
}
