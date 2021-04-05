package com.example.app.Funciones_Pantallas

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.widget.EditText
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.android.volley.Request
import com.android.volley.toolbox.StringRequest
import com.android.volley.toolbox.Volley
import com.example.app.R
import kotlinx.android.synthetic.main.activity_main.*
import kotlinx.android.synthetic.main.content_main.*
import kotlin.collections.ArrayList

class MainActivity : AppCompatActivity() {

    //Se crea el array para almacenar los usuarios creados
    var usuarios_registrados = ArrayList<String>()

    //Se crea el array para almacenar las contraseñas guardadas
    var contrsenas_registradas = ArrayList<String>()

    override fun onCreate(savedInstanceState: Bundle?) {

        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        setSupportActionBar(toolbar)

        //Variables para recibir los datos de entrada de usuario y contraseña
        val usuario_input = findViewById<EditText>(R.id.inputusuario) as EditText
        val contrasena_inpurt = findViewById<EditText>(R.id.inputcontrasena) as EditText

        //Se almacenan dos valores iniciales para las pruebas primarias
        // Usuario: estudiantea@estudiantes.ac.cr
        // Contraseñas_ 123456
        usuarios_registrados.add("estudiantea@estudiantes.ac.cr")
        contrsenas_registradas.add("123456")

        //Botón de acceso a la ventana de Administrar Carrito
        btnentrar.setOnClickListener {

            //Validaciones para continuar en la aplicación

            //Si el usuario no ha ingresado ningún dato de entrada
            if (usuario_input.text.toString().isNullOrEmpty() || contrasena_inpurt.text.toString().isNullOrEmpty() ){
                //Se despliega un mensaje de alerta solicitando datos válidos para el ingreso
                Toast.makeText(this, "Favor ingresar datos válidos", Toast.LENGTH_LONG).show()
            }
            else{
                val url = "http://192.168.1.3/WebServiceResTEC/api/dishes/"
                val queue = Volley.newRequestQueue(this)
                val stringRequest = StringRequest(Request.Method.GET, url, {
                    response ->
                    val intent = Intent(this, Cartilla::class.java)
                    intent.putExtra("informacion", response.toString())
                    startActivity(intent)
                    this.finish()
                }, {
                    Log.i("log", "Error")
                })
                queue.add(stringRequest)
            }
        }

        //Botón de acceso a la ventana de Registro
        btnregistrarse.setOnClickListener {
            startActivity(Intent(this, Registrarse::class.java))
        }
    }
}
