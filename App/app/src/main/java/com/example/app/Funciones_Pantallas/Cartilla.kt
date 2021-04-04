package com.example.app.Funciones_Pantallas

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.example.app.Especiales.Platillo
import com.example.app.R
import kotlinx.android.synthetic.main.opciones_menu.*


class Cartilla: AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.opciones_menu)

        val intent = getIntent()
        val informacion = intent.getStringExtra("informacion")

        val platillo = Convertir(informacion)

        Log.i("DISPONIBLES", platillo.get(0).descripcion_platillo)

        val total_menu = platillo.size

        var numero_platillo = 0

        //Se crea el array para almacenar los menus seleccionados
        val platillos_seleccionados = ArrayList<String>()
        val descripcion_selccionados = ArrayList<String>()
        val precio_seleccionados = ArrayList<String>()
        val ingredientes_seleccionados = ArrayList<String>()
        val tiempo_seleccionados = ArrayList<String>()

        //Etiquetas de informacion
        val fondo = findViewById<TextView>(R.id.lblfondo) as TextView
        val nombre_menu = findViewById<TextView>(R.id.lblmenu) as TextView
        val descripcion_menu = findViewById<TextView>(R.id.lbldescripcion) as TextView
        val ingredientes_menu = findViewById<TextView>(R.id.lblingredientes) as TextView
        val precio_menu = findViewById<TextView>(R.id.lblprecio) as TextView

        //Se muestra información del primer menu disponible en la aplicación
        nombre_menu.setText(platillo.get(numero_platillo).nombre_platillo)
        descripcion_menu.setText(platillo.get(numero_platillo).descripcion_platillo)
        ingredientes_menu.setText(platillo.get(numero_platillo).ingredientes_platillo)
        precio_menu.setText(platillo.get(numero_platillo).precio_platillo)

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
                precio_seleccionados.add(platillo.get(numero_platillo).precio_platillo)
                //codigo_seleccionados.add(platillo.get(numero_platillo).codigo_platillo)
                tiempo_seleccionados.add(platillo.get(numero_platillo).tiempo_platillo)
                Toast.makeText(this, "Item agregado", Toast.LENGTH_LONG).show()
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
                intent.putExtra("tiempos", tiempo_seleccionados)
                startActivity(intent)
            }
        }
    }

    private fun Convertir(entrada: String): ArrayList<Platillo>{
        var menus : List<String>
        var menus_disponibles = ArrayList<Platillo>()

        menus = entrada.split("}")

        for (i in 0 until (menus.size-1)) {
            //Aquí obtenego los diferentes elementos en forma de array
            //El último no interesa
            menus_disponibles.add(Platillo(TomarElemento(menus[i]).get(0), TomarElemento(menus[i]).get(1), TomarElemento(menus[i]).get(2),
                    TomarElemento(menus[i]).get(3),TomarElemento(menus[i]).get(4)))
        }
        return menus_disponibles
    }

    private fun TomarElemento(hilera: String) : ArrayList<String>{

        val item : List<String>
        var menu_display = ArrayList<String>()
        item =  hilera.split(":")

        val nombre = item[2].split(",").get(0) //Nombre del platillo
        val descripcion = item[3].substring(1, item[3].length-9) //Descripcion del platillo
        val precio = item[4].split(",").get(0) //Precio de preparación
        val ingredientes = item[6].substring(1, item[6].length-12) //Ingredientes del platillo
        val tiempo_prep = item[7].split(",").get(0) //Tiempo de preparación

        menu_display.add(nombre)
        menu_display.add(descripcion)
        menu_display.add(precio)
        menu_display.add(ingredientes)
        menu_display.add(tiempo_prep)

        return menu_display
    }
}