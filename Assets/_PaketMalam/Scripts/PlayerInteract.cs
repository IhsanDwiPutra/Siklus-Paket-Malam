using UnityEngine; // Library dasar Unity

public class PlayerInteract : MonoBehaviour { // Membuat kelas PlayerInteract untuk interaksi pemain
    public float jarakInteraksi = 3f; // Mengatur seberapa jauh pemain bisa berinteraksi dengan objek
    public Camera kameraPemain; // Menyimpan referensi kamera pemain untuk titik tengah pandangan
    public Camera kameraMotor; // Menyimpan referensi kamera yang ada di motor
    public MotorMovement scriptMotor; // Menyimpan referensi script mesin motor
    public GameObject uiCatatan; // Menyimpan referensi UI Catatan

    private void Update() { // Fungsi yang dipanggil setiap frame
        if (Input.GetKeyDown(KeyCode.F)) { // Mengecek apakah pemain menekan tombol 'F' di keyboard
            CobaInteraksi(); // Memanggil fungsi CobaInteraksi di bawah jika menekan tombol 'F' ditekan
        }

        if (Input.GetKeyDown(KeyCode.X)) { // Jika tombol 'X' ditekan
            if (uiCatatan != null) uiCatatan.SetActive(false); // Matikan teks catatan di layar
        }
    }

    void CobaInteraksi() { // Fungsi buatan sendiri untuk melakukan tembakan laser (Raycast)
        Ray laserPandangan = new Ray(kameraPemain.transform.position, kameraPemain.transform.forward); // Membuat garis laser imajiner dari posisi kamera lurus ke depan
        RaycastHit infoObjekTerkena; // Variabel untuk menyimpan informasi objek apa yang tertabrak laser

        if (Physics.Raycast(laserPandangan, out infoObjekTerkena, jarakInteraksi)) { // Menembakkan laser sejauh jarakInteraksi. Jika menabrak sesuatu, hasilnya true
            if (infoObjekTerkena.collider.CompareTag("Motor")) { // Mengecek apakah objek yang ditabrak memiliki Tag bernama "Motor"
                NaikMotor(); // Memanggil fungsi NaikMotor di bawah
            } else if (infoObjekTerkena.collider.CompareTag("Catatan")) {
                uiCatatan.SetActive(true); // Munculkan teks catatan
                Debug.Log("Membaca catatan bos!");
            }
        }
    }

    void NaikMotor() { // Fungsi untu Naik Motor
        kameraMotor.gameObject.SetActive(true); // 1. Nyalakan kamera motor

        scriptMotor.sedangDikendarai = true; // Menyalakan saklar agar motor bisa digerakkan!

        gameObject.SetActive(false); // 2. Matikan seluruh tubuh pemain (Capsule) beserta kamera pemainnya

        Debug.Log("Berhasil pindah ke kamera motor!"); // 3. Tampilkan pesan sukses di Console
    }

}