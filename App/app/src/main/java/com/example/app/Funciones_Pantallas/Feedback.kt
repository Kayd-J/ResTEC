package com.example.app.Funciones_Pantallas

import android.os.Bundle
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.example.app.R
import kotlinx.android.synthetic.main.feedback.*

class Feedback : AppCompatActivity(){
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.feedback)

        //Esta sección de códgio sireve para mostrar la información de fecha y hora
        val calendario:java.util.Calendar = java.util.Calendar.getInstance()

        //El formato es Día-Mes-Año  Horas-Minuto
        val dia = calendario.get(java.util.Calendar.DAY_OF_MONTH)
        val mes = calendario.get(java.util.Calendar.MONTH)
        val ano = calendario.get(java.util.Calendar.YEAR)
        val hora = calendario.get(java.util.Calendar.HOUR_OF_DAY)
        val minuto = calendario.get(java.util.Calendar.MINUTE)

        //Se nombra el label para mostrar la fecha y hora
        val fechahora = findViewById<TextView>(R.id.lblfecha_hora) as TextView

        //Se nombrea en text input del comentario
        val comentario = findViewById<EditText>(R.id.inputfeedback) as EditText

        //Se imprime la fecha y hora
        //Se nombra el label para mostrar la fecha y hora
        fechahora.text = "$dia-$mes-$ano   $hora-$minuto"

        var puntaje:Float = 0.0f

        ratingBar.setOnRatingBarChangeListener{ratingBar, calificacion, b->
            Toast.makeText(this, calificacion.toString(), Toast.LENGTH_SHORT).show()
            puntaje = calificacion
            }

        btnenviar.setOnClickListener {
            //Aquí se envian los datos JSON al Rest
            }
        }
    }
