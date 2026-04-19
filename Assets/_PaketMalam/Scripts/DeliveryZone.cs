using UnityEngine; // Pustaka dasar Unity

public class DeliveryZone : MonoBehaviour { // Membuat kelas untuk Zona COD
    public GameObject uiMenang; // Variabel untuk menyimpan objek teks layar



    // OnTriggerEnter adalah fungsi bawaan Unity yang otomatis terpanggil saat ada objek masuk ke dalam zona 'Trigger'
    private void OnTriggerEnter(Collider objekYangMasuk) {
        // Mengecek apakah objek yang menembus zona ini memiliki Tag "Player" (Kapsul Pemain)
        if (objekYangMasuk.CompareTag("Player")) {
            uiMenang.SetActive(true); // Menyalakan (memunculkan) objek teks di layar pemain

            // Menampilkan pesan sukses di jendela Console
            Debug.Log("Paket berhasil diantar ke pelanggan! Siklus 1 Paket selesai!");
        }
    }
}