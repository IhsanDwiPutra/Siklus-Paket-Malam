using UnityEngine; // Menggunakan pustaka/library dasar Unity

public class PlayerMovement : MonoBehaviour { // Membuat kelas PlayerMovement
    public float kecepatanJalan = 5f; // Mengatur kecepatan jalan karakter
    public float sensitivitasMouse = 2f; // Mengatur seberapa sensitif putaran mosue
    public Transform kameraPemain; // Menyimpan referensi kamera untuk melihat ke atas/bawah

    private CharacterController kontroler; // Variabel untuk menyimpan Character Controller
    private float rotasiX = 0f; // Menyimpan nilai rotasi kamera vertikal (atas/bawah)

    private void Start() { // Fungsi yang dipanggil sekali saat game dimulai
        kontroler = GetComponent<CharacterController>(); // Mengambil komponen Character Controller dari kapsul
        Cursor.lockState = CursorLockMode.Locked; // Mengunci kursor mouse di tengah layar agar tidak keluar jendela game
    }

    private void Update() { // Fungsi yang dipanggil setiap frame (terus-menerus)
        // - Melihat Sekeliling (Mouse Look) -
        float mouseX = Input.GetAxis("Mouse X") * sensitivitasMouse; // Mengambil gerakan mouse ke kiri/kanan
        float mouseY = Input.GetAxis("Mouse Y") * sensitivitasMouse; // Mengambil gerakan mouse ke atas/bawah

        rotasiX -= mouseY; // Mengurangi nilai rotasi vertikal berdasarkan gerakan mouse
        rotasiX = Mathf.Clamp(rotasiX, -90f, 90f); // Membatasi putaran kepala agar tidak terbalik (maksimal 90 derajat)

        kameraPemain.localRotation = Quaternion.Euler(rotasiX, 0f, 0f); // Memutar kamera ke atas/bawah
        transform.Rotate(Vector3.up * mouseX); // Memutar tubuh pemain (kapsul) ke kiri/kanan

        // - Berjalan (WASD)
        float majuMundur = Input.GetAxis("Vertical"); // Mengambil input tombol W/S (maju mundur)
        float kiriKanan = Input.GetAxis("Horizontal"); // Mengambil input tombol A/D (kiri kanan)

        Vector3 pergerakan = transform.right * kiriKanan + transform.forward * majuMundur; // Menentukan arah gerak berdasarkan posisi tubuh
        kontroler.SimpleMove(pergerakan * kecepatanJalan); // Menggerakkan karakter. Fitur 'SimpleMove' otomatis menambahkan gravitasi!
    }



}