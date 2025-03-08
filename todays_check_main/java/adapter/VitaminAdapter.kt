package adapter

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.DiffUtil
import androidx.recyclerview.widget.ListAdapter
import androidx.recyclerview.widget.RecyclerView
import com.example.vitacheck.databinding.ItemVitaminBinding
import database.Vitamin

class VitaminAdapter(
    private var vitamins: List<Vitamin>,
    private val onCheckChanged: (Vitamin) -> Unit
) : ListAdapter<Vitamin, VitaminAdapter.VitaminViewHolder>(VitaminDiffCallback()) {

    inner class VitaminViewHolder(private val binding: ItemVitaminBinding) :
        RecyclerView.ViewHolder(binding.root) {

        fun bind(vitamin: Vitamin) {
            binding.vitaminName.text = vitamin.name
            binding.vitaminDays.text = vitamin.days
            binding.vitaminCheckBox.isChecked = vitamin.isChecked
            binding.vitaminCheckBox.setOnCheckedChangeListener { _, _ ->
                onCheckChanged(vitamin)
            }
        }
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): VitaminViewHolder {
        val binding = ItemVitaminBinding.inflate(
            LayoutInflater.from(parent.context),
            parent,
            false
        )
        return VitaminViewHolder(binding)
    }

    override fun onBindViewHolder(holder: VitaminViewHolder, position: Int) {
        holder.bind(vitamins[position])
    }

    override fun getItemCount(): Int = vitamins.size

    // DiffUtilのためのCallback実装
    class VitaminDiffCallback : DiffUtil.ItemCallback<Vitamin>() {
        override fun areItemsTheSame(oldItem: Vitamin, newItem: Vitamin): Boolean {
            return oldItem.id == newItem.id
        }

        override fun areContentsTheSame(oldItem: Vitamin, newItem: Vitamin): Boolean {
            return oldItem == newItem
        }
    }

    // データ更新時に呼び出し
    fun updateData(newVitamins: List<Vitamin>) {
        this.vitamins = newVitamins
        submitList(newVitamins)
    }
}