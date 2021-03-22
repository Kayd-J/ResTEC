package com.example.app

import android.content.Intent
import android.os.Bundle
import android.view.View
import android.widget.*
import androidx.appcompat.app.AppCompatActivity
import kotlinx.android.synthetic.main.administrar_carrito.*
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

class AdministrarCarrito: AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.administrar_carrito)

        //Se inicializa una varaible para llevar el total del monto
        var cantidad_producto = 0

        var preparacion = 0

        //Se identifican los labels para mostrar las información de total y platillo
        val total = findViewById<TextView>(R.id.lbltotal) as TextView
        val item = findViewById<TextView>(R.id.lblitem) as TextView

        //Se inicializan las variables para poder recibir información de los arraylist
        //de los platillos recibidos y precios recibidos pero de la ventana de
        //Administrar Carrito
        val intent = getIntent()
        val platillos_recibidos = intent.getStringArrayListExtra("platillos")
        val precio_recibidos = intent.getStringArrayListExtra("precios")
        val codigo_recibidos = intent.getStringArrayListExtra("codigos")
        val tiempo_recibidos = intent.getStringArrayListExtra("tiempos")

        //Variables para el conteo de productos según su precio
        var costoinidividual = 0

        var tiempo_pre = 0

        var indice = 0

        //Se crea un spinner para mostar los platillos seleccionados por el usuario
        val menu = findViewById<Spinner>(R.id.spnseleccinados)

        //Se toman las listas de arrays creadas en la sección de values/strings del proyecto para
        //poder trabajar con ellos y mostrar lo que estan almacenan en la interfaz
        val menu_lista = ArrayAdapter(this,android.R.layout.simple_spinner_item, platillos_recibidos)
        menu.adapter = menu_lista

        menu.onItemSelectedListener = object: AdapterView.OnItemSelectedListener{
            //Función implementada cuando es seleccionado uno de los elementos del spinner de platillos
            //El elemento importante es el id, ya que este dará la posición en el array de opciones
            override fun onItemSelected(parent: AdapterView<*>?, view: View?, position: Int, id: Long) {

                //Se selecciona el elemento del usuario y se procede a mostrarlo en la interfaz
                val seleccion = platillos_recibidos[position].toString()
                val seleccion2 = precio_recibidos[position].toString()
                item.setText(seleccion)
                //total.setText(seleccion2)

                costoinidividual = precio_recibidos[position].toString().toInt()

                tiempo_pre = tiempo_recibidos[position].toString().toInt()

                indice = position
            }
            override fun onNothingSelected(parent: AdapterView<*>?) {
                TODO("Not yet implemented")
            }
        }

        //Boton para incrementar la cantidad de platillos según el seleccionado
        btnmas.setOnClickListener {
            cantidad_producto += costoinidividual
            preparacion += tiempo_pre
            total.setText(cantidad_producto.toString())
        }

        //Boton para disminuir la cantidad de platillos según el seleccionado
        btnmenos.setOnClickListener {
            cantidad_producto -= costoinidividual
            preparacion -= tiempo_pre
            total.setText(cantidad_producto.toString())
        }

        //Botón para eliminar un opción de los platillos seleccionados
        btneliminar.setOnClickListener {
            platillos_recibidos.removeAt(indice)
            precio_recibidos.removeAt(indice)
        }

        //Botón de acceso a la ventana de Generar Pedido
        btnconfirmar.setOnClickListener {

            if (lbltotal.text.toString() == "total"){
                Toast.makeText(this, "Favor agregar un platillo al carrito", Toast.LENGTH_LONG).show()
            }
            else
            {
            val intent = Intent(this, GenerarPedido::class.java)
            intent.putExtra("total", cantidad_producto.toString())
            intent.putExtra("orden", platillos_recibidos)
            intent.putExtra("tiempo", preparacion.toString())
            startActivity(intent)
            }
        }
    }

    private fun getRetrofit(): Retrofit {
        return Retrofit.Builder()
            .baseUrl("https://dog.ceo/api/breed/")
            .addConverterFactory(GsonConverterFactory.create())
            .build()
    }

    private fun searchByName(query:String){
        CoroutineScope(Dispatchers.IO).launch {
            val call = getRetrofit().create(ApiService::class.java).TomarDatos("$query/images")
            val puppies = call.body()
            runOnUiThread {
                if(call.isSuccessful){

                }else{
                    
                }
            }
        }
    }
}