using UnityEngine; // Pustaka dasar Unity

public class MotorMovement : MonoBehaviour { // Membuat kelas pergerakan motor
    public float kecepatanMaju = 10f; // Mengatur seberapa cepat motor melaju
    public float kecepatanBelok = 60f; // Mengatur seberapa cepat motor berputar/belok
    public bool sedangDikendarai = false; // Penanda (saklar) apakah pemain sudah naik motor
    public GameObject tubuhPemain; // Menyimpan referensi kapsul pemain agar bisa dihidupkan
    public Camera kameraMotor; // Menyimpan referensi kamera motor agar bisa dimatikan
    public Transform titikTurun; // Menyimpan posisi untuk memunculkan pemain

    private void Update() { // Fungsi yang dipanggil terus menerus
        // Jika saklar sedangDikendarai bernilai salah (false), abaikan kode dibawahnya!
        if (sedangDikendarai == false) return;

        // Mengambil input dari keyboard (WASD atau Panah)
        float majuMundur = Input.GetAxis("Vertical"); // mengambil input maju mundur dari keyboard
        float kiriKanan = Input.GetAxis("Horizontal"); // mengambil input kiri kanan dari keyboard

        // Menggerakkan motor ke depan/belakang. Time.deltaTime membuat gerakan mulus per detik.
        transform.Translate(Vector3.forward * majuMundur * kecepatanMaju * Time.deltaTime);

        // Memutar arah motor ke kiri/kanan
        transform.Rotate(Vector3.up * kiriKanan * kecepatanBelok * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.G)) { // Jika tombol 'G' ditekan
            TurunMotor(); // Panggil fungsi di bawah
        }
    }

    void TurunMotor() {
        sedangDikendarai = false; // 1. Matikan saklar mesin motor
        kameraMotor.gameObject.SetActive(false); // 2. Matikan kamera motor

        tubuhPemain.transform.position = titikTurun.position; // 3. Pindahkan posisi kapsul yang sedang mati ke Titik Turun
        tubuhPemain.SetActive(true); // 4. Nyalakan kembali kapsul pemain (kamera pemain otomatis ikut nyala)

        Debug.Log("Pemain berhasil turun dari motor!"); // 5. Pesan sukses di Console

    }
}