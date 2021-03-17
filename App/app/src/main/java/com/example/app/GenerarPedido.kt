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

        val label = findViewById<TextView>(R.id.lbltotala) as TextView

        val intent = getIntent()
        val total = intent.getStringExtra("total")

        label.setText("Total: $total")


        val calendario:java.util.Calendar = java.util.Calendar.getInstance()

        val dia = calendario.get(java.util.Calendar.DAY_OF_MONTH)
        val mes = calendario.get(java.util.Calendar.MONTH)
        val ano = calendario.get(java.util.Calendar.YEAR)
        val hora = calendario.get(java.util.Calendar.HOUR_OF_DAY)
        val minuto = calendario.get(java.util.Calendar.MINUTE)

        val fecha = findViewById<TextView>(R.id.lblhora) as TextView

        fecha.text = "$dia-$mes-$ano   $hora-$minuto"


        val consecutivo = findViewById<TextView>(R.id.lblconsec)

        consecutivo.setText("0001")

        //Botón de acceso a la ventana de Visualizar
        btnvisualizar.setOnClickListener {
            startActivity(Intent(this, Visualizar::class.java))
        }
    }
}