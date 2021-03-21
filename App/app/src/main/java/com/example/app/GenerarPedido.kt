package com.example.app

import android.content.Intent
import android.os.Build
import android.os.Bundle
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import kotlinx.android.synthetic.main.content_main.*
import kotlinx.android.synthetic.main.generar_pedido.*

class GenerarPedido: AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.generar_pedido)

        //Se identifican los label para mostrar la información
        val label = findViewById<TextView>(R.id.lbltotala) as TextView
        val orden_display = findViewById<TextView>(R.id.lblplatillos) as TextView

        //Se recibe la información proveniente de la ventana de Menu
        //Lo que se reciben son dos arraylist que contiene la iformación de los paltillos seleccionados
        //y el label que coniene los precios de los menus seleccionados
        val intent = getIntent()
        val total = intent.getStringExtra("total")
        val orden = intent.getStringArrayListExtra("orden")
        val tiempo = intent.getStringExtra("tiempo")

        //Se muestra en pantalla el total en pantalla según lo items seleccionados
        label.setText("Total: $total")
        orden_display.setText(orden.toString())

        //Esta sección de códgio sireve para mostrar la información de fecha y hora
        val calendario:java.util.Calendar = java.util.Calendar.getInstance()

        //El formato es Día-Mes-Año  Horas-Minuto
        val dia = calendario.get(java.util.Calendar.DAY_OF_MONTH)
        val mes = calendario.get(java.util.Calendar.MONTH)
        val ano = calendario.get(java.util.Calendar.YEAR)
        val hora = calendario.get(java.util.Calendar.HOUR_OF_DAY)
        val minuto = calendario.get(java.util.Calendar.MINUTE)

        //Se nombra el label para mostrar la fecha y hora
        val fecha = findViewById<TextView>(R.id.lblhora) as TextView

        //Se imprime la fecha y hora
        fecha.text = "$dia-$mes-$ano   $hora-$minuto"

        //Se slecciona el label de consecutivo
        val consecutivo = findViewById<TextView>(R.id.lblconsec)

        //Se imprime el consecutivo del recibo
        consecutivo.setText("0001")

        //Botón de acceso a la ventana de Visualizar
        btnvisualizar.setOnClickListener {
            val intent = Intent(this, Visualizar::class.java)
            intent.putExtra("preparacion", tiempo)
            startActivity(intent)
            //startActivity(Intent(this, Visualizar::class.java))
        }
    }
}