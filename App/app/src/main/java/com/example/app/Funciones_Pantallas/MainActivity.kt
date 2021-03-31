package com.example.app.Funciones_Pantallas

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.android.volley.Request
import com.android.volley.RequestQueue
import com.android.volley.Response
import com.android.volley.toolbox.StringRequest
import com.android.volley.toolbox.Volley
import com.example.app.R
import com.example.app.services.DataService
import com.example.app.services.ServiceBuilder
import kotlinx.android.synthetic.main.activity_main.*
import kotlinx.android.synthetic.main.content_main.*
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch


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

        val label = findViewById<TextView>(R.id.lblnombreu) as TextView

        senGetRequest()

        //Se almacenan dos valores iniciales para las pruebas primarias
        // Usuario: estudiantea@estudiantes.ac.cr
        // Contraseñas_ 123456
        usuarios_registrados.add("estudiantea@estudiantes.ac.cr")
        contrsenas_registradas.add("123456")

        //Botón de acceso a la ventana de Administrar Carrito
        btnentrar.setOnClickListener {

            val intent = getIntent()
            val usariorecibido = intent.getStringArrayListExtra("usuario")
            val cantrasenarecibo = intent.getStringExtra("contrasena")

            val usuario = usuario_input.text.toString()
            val contrasena = contrasena_inpurt.text.toString()

            //Toast.makeText(this, usariorecibido[0] + " 4", Toast.LENGTH_LONG).show()

            //Validaciones para continuar en la aplicación

            //Si el usuario no ha ingresado ningún dato de entrada
            if (usuario_input.text.toString().isNullOrEmpty() || contrasena_inpurt.text.toString().isNullOrEmpty() ){
                //Se despliega un mensaje de alerta solicitando datos válidos para el ingreso
                Toast.makeText(this, "Favor ingresar datos válidos", Toast.LENGTH_LONG).show()
            }
            else{
                startActivity(Intent(this, Cartilla::class.java))
            }

            //Se realiza una comprobación para corroboar el usuario y la contraseña
            //verificar(usuario, contrasena)
        }

        //Botón de acceso a la ventana de Registro
        btnregistrarse.setOnClickListener {
            startActivity(Intent(this, Registrarse::class.java))
        }

    }

    private fun senGetRequest(){
        val url = "https://192.168.1.3:5001/api/dishes/"
        //val url = "https://dog.ceo/api/breed/akita/images"
        //val url = "https://192.168.1.3/server/api/Clientes/getlogin"
        val queue = Volley.newRequestQueue(this)
        val stringRequest = StringRequest(Request.Method.GET, url, {
            response ->
            Log.i("log", response)
            //Toast.makeText(this, response.toString(), Toast.LENGTH_SHORT).show()
        }, {
            Log.i("log", "Error")
            //Toast.makeText(this, "ERROR", Toast.LENGTH_SHORT).show()
        })
        queue.add(stringRequest)
    }
}
