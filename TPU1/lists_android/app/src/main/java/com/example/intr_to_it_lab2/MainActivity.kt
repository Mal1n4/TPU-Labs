package com.example.intr_to_it_lab2

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.ListView
import android.widget.Toast
import android.widget.SimpleAdapter

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        //Формирование матрицы со странами
        val countries = ArrayList<Map<String, Any>>()
        var item: MutableMap<String, Any>
        item = HashMap()
        item["title"] = "Россия"
        item["info"] = "Спасская башня"
        item["photo"] = R.drawable.spasskaya
        item["capital"] = "Москва"
        countries.add(item)
        item = HashMap()
        item["title"] = "Украина"
        item["info"] = "Дом с химерами"
        item["photo"] = R.drawable.the_house_with_chimeras
        item["capital"] = "Киев"
        countries.add(item)
        item = HashMap()
        item["title"] = "Польша"
        item["info"] = "Вилянувский дворец"
        item["photo"] = R.drawable.wilanow_palace
        item["capital"] = "Варшава"
        countries.add(item)
        item = HashMap()
        item["title"] = "Белоруссия"
        item["info"] = "Красный костёл"
        item["photo"] = R.drawable.red_church
        item["capital"] = "Минск"
        countries.add(item)
        item = HashMap()
        item["title"] = "Казахстан"
        item["info"] = "Хан Шатыр"
        item["photo"] = R.drawable.han_shatir
        item["capital"] = "Астана"
        countries.add(item)
        //Подготовка адаптера
        val from = arrayOf<String>("title", "info", "photo")
        val to = intArrayOf(R.id.title, R.id.info, R.id.icon)
        val adapter = SimpleAdapter(this, countries, R.layout.my_list_item_advanced, from, to)
        val listView: ListView = findViewById(R.id.listView)
        listView.adapter = adapter
        //Установка "листнера" для выведения подсказок
        listView.setOnItemClickListener { parent, view, position, id ->
            //val textView = view.findViewById<TextView>(R.id.title)
            val toast: Toast = Toast.makeText(this,"Столица: " + countries[position]["capital"], Toast.LENGTH_SHORT)
            toast.show()
        }

    }
}