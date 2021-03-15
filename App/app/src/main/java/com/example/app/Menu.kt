package com.example.app

import android.content.Intent
import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import kotlinx.android.synthetic.main.content_main.*
import kotlinx.android.synthetic.main.menu.*


class Menu: AppCompatActivity() {

    /**
    Aquí se crea un pequeño arraylist, de todos los platillos que la aplicación administrará para poner
      a disposición del cliente, estos contienen el nombre, la descripción  y un código, este último tiene
      como función asociar aquellos platillos que vienen del Restful Api para poder mostar solo los que
      el Administrador este habilitando en dicho momento
     * **/
    val platillo: List<Platillos> = listOf(
        Platillos("Desayuno", "1","gallo pinto, huevo, pan y natillas", "https://pbs.twimg.com/media/De9ux_AUYAABwHL.jpg", 500) ,
        Platillos("Cena", "2","SUSHI", "https://i.pinimg.com/originals/02/03/cc/0203cc0123d33a772361dc4c8797f269.jpg",600),
        Platillos("Almuerzo", "3","pescado frito", "https://goodbread.co/images/breakfast1.jpg",1500),
        Platillos("Típico", "4","casado con fresco natural", "https://media.cntraveler.com/photos/5f5fad3f7557491753644e3b/3:2/w_4050,h_2700,c_limit/50States50Cuisines-2020-AmberDay-Lede%20Option.jpg",800),
        Platillos("", "","ACEPTAR", "http://iconbug.com/data/9e/320/f091bc243f41dce0e3eaa3d6848234c6.png",0)
    )

    override fun onCreate(savedInstanceState: Bundle?) {

        super.onCreate(savedInstanceState)
        setContentView(R.layout.menu)
        IncializarPlatillos()
    }

    fun IncializarPlatillos(){
        recycleviewplatillos.layoutManager = LinearLayoutManager(this)
        val adapter = PlatillosAdapter(platillo, this)
        recycleviewplatillos.adapter = adapter

    }
}