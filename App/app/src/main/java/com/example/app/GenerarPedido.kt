package com.example.app

import android.content.Intent
import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import kotlinx.android.synthetic.main.content_main.*
import kotlinx.android.synthetic.main.generar_pedido.*

class GenerarPedido: AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.generar_pedido)

        //Botón de acceso a la ventana de Visualizar
        btnvisualizar.setOnClickListener {
            startActivity(Intent(this, Visualizar::class.java))
        }
    }
}