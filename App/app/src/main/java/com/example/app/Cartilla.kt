package com.example.app

import android.content.Intent
import android.os.Bundle
import android.widget.EditText
import android.widget.ImageView
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.squareup.picasso.Picasso
import kotlinx.android.synthetic.main.administrar_carrito.*
import kotlinx.android.synthetic.main.opciones_menu.*


class Cartilla: AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.opciones_menu)

        /**
        Aquí se crea un pequeño arraylist, de todos los platillos que la aplicación administrará para poner
        a disposición del cliente, estos contienen el nombre, la descripción  y un código, este último tiene
        como función asociar aquellos platillos que vienen del Restful Api para poder mostar solo los que
        el Administrador este habilitando en dicho momento
         * **/
        val platillo: ArrayList<Platillos> = arrayListOf(
                Platillos("Desayuno", "1","gallo pinto, huevo, pan y natillas", "https://pbs.twimg.com/media/De9ux_AUYAABwHL.jpg", 500,100) ,
                Platillos("Cena", "2","SUSHI", "https://i.pinimg.com/originals/02/03/cc/0203cc0123d33a772361dc4c8797f269.jpg",600,200),
                Platillos("Almuerzo", "3","pescado frito", "https://goodbread.co/images/breakfast1.jpg",1500,300),
                Platillos("Típico", "4","casado con fresco natural", "https://media.cntraveler.com/photos/5f5fad3f7557491753644e3b/3:2/w_4050,h_2700,c_limit/50States50Cuisines-2020-AmberDay-Lede%20Option.jpg",800,400),
                Platillos("", "","ACEPTAR", "http://iconbug.com/data/9e/320/f091bc243f41dce0e3eaa3d6848234c6.png",0,500)
        )

        val total_menu = platillo.size

        var numero_platillo = 0

        //Se crea el array para almacenar los menus seleccionados
        val platillos_seleccionados = ArrayList<String>()
        val precio_seleccionados = ArrayList<String>()
        val codigo_seleccionados = ArrayList<String>()
        val tiempo_seleccionados = ArrayList<String>()

        //Etiquetas de informacion
        val fondo = findViewById<TextView>(R.id.lblfondo) as TextView
        val nombre_menu = findViewById<TextView>(R.id.lblmenu) as TextView
        val descripcion_menu = findViewById<TextView>(R.id.lbldes) as TextView
        val precio_menu = findViewById<TextView>(R.id.lblprecio) as TextView

        //Se muestra información del primer menu disponible en la aplicación
        nombre_menu.setText(platillo.get(numero_platillo).nombre_platillo)
        descripcion_menu.setText(platillo.get(numero_platillo).descripcion_platillo)
        precio_menu.setText(platillo.get(numero_platillo).precio_platillo.toString())


        //Botón para avanzar a lo largo de los menus disponibles
        btnatras.setOnClickListener {
            if (numero_platillo <= 0){
                numero_platillo = total_menu
            }
            else{
                numero_platillo--
                nombre_menu.setText(platillo.get(numero_platillo).nombre_platillo)
                descripcion_menu.setText(platillo.get(numero_platillo).descripcion_platillo)
                precio_menu.setText(platillo.get(numero_platillo).precio_platillo.toString())
            }
        }

        //Botón para retroceder a lo largo de los menus disponibles
        btnsiguiente.setOnClickListener {
            if (numero_platillo >= total_menu){
                numero_platillo = 0
            }
            else{
                numero_platillo++
                nombre_menu.setText(platillo.get(numero_platillo).nombre_platillo)
                descripcion_menu.setText(platillo.get(numero_platillo).descripcion_platillo)
                precio_menu.setText(platillo.get(numero_platillo).precio_platillo.toString())
            }
        }

        //Boton para agregar al carrito
        btnagregar.setOnClickListener {
                platillos_seleccionados.add(platillo.get(numero_platillo).nombre_platillo)
                precio_seleccionados.add(platillo.get(numero_platillo).precio_platillo.toString())
                codigo_seleccionados.add(platillo.get(numero_platillo).codigo_platillo)
                tiempo_seleccionados.add(platillo.get(numero_platillo).tiempo.toString())
                Toast.makeText(this, platillos_seleccionados.toString(), Toast.LENGTH_LONG).show()
        }

        //Boton para comprar y avanzar a la ventana de Administrar Carrito
        //Aquí se hace una validación para que el usario escoja al menos una aplicación
        btncomprar.setOnClickListener {
            if(platillos_seleccionados.size == 0){
                Toast.makeText(this, "Debe agregar un item al carrito", Toast.LENGTH_LONG).show()
            }
            else {
                val intent = Intent(this, AdministrarCarrito::class.java)
                intent.putExtra("platillos", platillos_seleccionados)
                intent.putExtra("precios", precio_seleccionados)
                intent.putExtra("codigos", codigo_seleccionados)
                intent.putExtra("tiempos", tiempo_seleccionados)
                startActivity(intent)
            }
        }
    }
}