package com.example.app.Funciones_Pantallas

import android.content.Intent
import android.os.Bundle
import android.widget.*
import androidx.appcompat.app.AppCompatActivity
import com.example.app.R
import com.example.app.Especiales.SeleccionFecha
import kotlinx.android.synthetic.main.registrarse.*

class Registrarse: AppCompatActivity() {

    //Se crea el array para almacenar los usuarios creados en la actividad de Registro
    var usuarios_registrados_r = ArrayList<String>()

    //Se crea el array para almacenar las contraseñas guardadas en la actividad de Registro
    var contrsenas_registradas_r = ArrayList<String>()

    override fun onCreate(savedInstanceState: Bundle?) {

        super.onCreate(savedInstanceState)
        setContentView(R.layout.registrarse)
        //Se llama la  función de SelecciónFecha
        inputfechac.setOnClickListener{ SelecciondeFecha() }

        //Variables para recibir los datos de entrada de usuario y contraseña
        val usuario_input = findViewById<EditText>(R.id.inputcorreor) as EditText
        val contrasena_input =  findViewById<EditText>(R.id.inputcontrasenar) as EditText

        //Sección de función para el botón de registrar
        btnregistrar.setOnClickListener {

            //Las variables toman los datos de entrada en la ventana de registro
            //Las que se deben almacenar en el array son usario y contraseña
            val usuario = usuario_input.text.toString()
            val contrasena = contrasena_input.text.toString()

            //Se almacenan los datos para que estos puedan ser enviados a la actividad principal
            //Se envían a la función de Almacenamiento para que se escriban en la posición siguiente
            //Esto evita que el array solo tenga un elemento guardado

            val registro_usuario = Almacenamiento(usuario, usuarios_registrados_r)
            val registro_contrasena = Almacenamiento(contrasena, contrsenas_registradas_r)

            /*
                Envío de datos tomar los datos del registro y contraseña que se hayan registrado
                Para enviarlos hacia la ventana principal
            */
            val intent = Intent(this, MainActivity::class.java)
            intent.putExtra("usuario", registro_usuario)
            //intent.putExtra("contrasena", registro_contrasena[0])
            startActivity(intent)

            //Toast.makeText(this@Registrarse, registro_usuario.toString(),Toast.LENGTH_LONG).show()

            //Es importante cerrar la activdad, de lo contrario, se abrirá una nueva entana principal
            //Y la información de registro no se enviará
            this.finish()
        }

    }

    /**
        Este par de funciones son las encargadas de seleccionar  y desplegar visualmente
        las fecha que sea escogida en el usuario en la ventana se usuario
     **/

    private fun SelecciondeFecha(){
        //Se envia a la función de Seleccion, la fecha dividida de la selección
        //Se invoca de igual forma la clase encargada del date picker
       val datePicker = SeleccionFecha {dia, mes, ano -> Seleccion(dia, mes, ano)}
        datePicker.show(supportFragmentManager, "Fecha")
    }

    fun Seleccion(dia:Int, mes:Int, ano:Int){
        //Se despliega en el inputtext de fecha el día, mes y año correspondiente
        inputfechac.setText("$dia-$mes-$ano")
    }

    /**
        La función de alamacenamiento coloca el correo y la contraseña de la nueva persona en un array
         de forma dinámica para poder almacenar la diferente información a lo largo del uso de este
         después este array es enviado a la ventana principal
     * **/
    //Función para almacenar un elemento en un array list en un posición idnicada e ir aumentando su tamaño
    fun Almacenamiento(elemento: String, elementos: ArrayList<String>): ArrayList<String>{

        //Si el tamaño del array es igual a cero se almacena el elemento en dicha
        if (elementos.size == 0){
            elementos.add(elemento)
            return elementos
        }
        //Si la posición es diferente de cero se toma la medida del largo del array y se le resta una
        //posición para colocar el nuevo elemento en la última posición del array y así no tener
        //conflictos
        else{
            val posicion = elementos.size -1
            elementos.add(posicion, elemento)
            return elementos
        }
    }
}

























/*

//Se declaran las variables para la sección de los spinner de provincia, canton y  dsitrito
        val provincia = findViewById<Spinner>(R.id.spnprovincia)
        val canton = findViewById<Spinner>(R.id.spncanton)
        val distrito = findViewById<Spinner>(R.id.spndistrito)

        //Se toman las listas de arrays creadas en la sección de values/strings del proyecto para
        //poder trabajar con ellos y mostrar lo que estan almacenan en la interfaz
        val provincias_lista = resources.getStringArray(R.array.provincias)

        val opciones_provincias = ArrayAdapter(this,android.R.layout.simple_spinner_dropdown_item, provincias_lista)
        provincia.adapter = opciones_provincias

        //Se implementa la función propia del spinner para cuando sea seleccionado un elemento del mismo
        provincia.onItemSelectedListener = object: AdapterView.OnItemSelectedListener{
            //Función implementada cuando es seleccionado uno de los elementos del spinner de provincias
            //El elemento importante es el id, ya que este dará la posición en el array de opciones
            override fun onItemSelected(parent: AdapterView<*>?, view: View?, position: Int, id: Long) {

                //Se selecciona la primera letra de la opción de provincia, ya que para esto
                //Se tiene que llamar de inmediato el spinner de los cantones según dicha provincia
                //El array de cantones tiene por nombre Iniicial de Provincia en Mayúscula + cantones
                val seleccion = provincias_lista[position].first().toString() + "cantones"
                Toast.makeText(this@Registrarse, seleccion,Toast.LENGTH_LONG).show()

            }
            override fun onNothingSelected(parent: AdapterView<*>?) {
                TODO("Not yet implemented")
            }
        }
* */