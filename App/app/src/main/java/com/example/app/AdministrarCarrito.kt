package com.example.app

import android.content.Intent
import android.os.Bundle
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import kotlinx.android.synthetic.main.administrar_carrito.*


class AdministrarCarrito: AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.administrar_carrito)

        var cantidad_producto = 0
        val label = findViewById<TextView>(R.id.lbltotal) as TextView

        val intent = getIntent()
        val usariorecibido = intent.getStringArrayListExtra("platillos")

        btnmas.setOnClickListener {
            cantidad_producto++
            label.setText(cantidad_producto.toString())
        }

        btnmenos.setOnClickListener {
            cantidad_producto--
            label.setText(cantidad_producto.toString())
        }

        //Botón de acceso a la ventana de Generar Pedido
        btnconfirmar.setOnClickListener {

            val intent = Intent(this, GenerarPedido::class.java)
            intent.putExtra("total", cantidad_producto.toString())
            startActivity(intent)
        }
    }


    fun Nueva_Venta(){
        startActivity(Intent(this, GenerarPedido::class.java))
    }
}