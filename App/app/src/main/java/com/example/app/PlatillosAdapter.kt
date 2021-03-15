package com.example.app

import android.content.Context
import android.content.Intent
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.core.content.ContextCompat.startActivity
import androidx.recyclerview.widget.RecyclerView
import com.squareup.picasso.Picasso
import kotlinx.android.synthetic.main.menu.view.*
import kotlinx.android.synthetic.main.platillo.view.*

class PlatillosAdapter( val platillo:List<Platillos>, private val contexto: Context):RecyclerView.Adapter<PlatillosAdapter.AdaptadorPlatillos>(){


    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): AdaptadorPlatillos {
        val layoutInflater = LayoutInflater.from(parent.context)
        return AdaptadorPlatillos(layoutInflater.inflate(R.layout.platillo, parent, false), contexto)
    }

    override fun getItemCount(): Int {
        return platillo.size
    }

    override fun onBindViewHolder(holder: AdaptadorPlatillos, position: Int) {
        holder.renderizar(platillo[position])
    }

    class AdaptadorPlatillos(val view:View, var contexto: Context): RecyclerView.ViewHolder(view){

        fun renderizar(platillo: Platillos){
            view.lblnombreplatillo.text = platillo.nombre_platillo
            view.lbldescripcion.text = platillo.descripcion_platillo
            view.lblcosto.text = platillo.precio_platillo.toString()
            Picasso.get().load(platillo.imagen_platillo).into(view.imgview)

            //Selección del intem del menú
            view.setOnClickListener {
                //Toast.makeText(view.context, platillo.nombre_platillo, Toast.LENGTH_SHORT).show()
                if(platillo.descripcion_platillo == "ACEPTAR"){
                    Toast.makeText(view.context, "Nueva_Ventana", Toast.LENGTH_SHORT).show()
                    contexto.startActivity(Intent(contexto, AdministrarCarrito::class.java))
                }
                else{
                    Toast.makeText(view.context, platillo.nombre_platillo, Toast.LENGTH_SHORT).show()
                }
            }
        }
    }

    fun start(){
       // startActivity(Intent(this, Menu::class.java))
    }
}