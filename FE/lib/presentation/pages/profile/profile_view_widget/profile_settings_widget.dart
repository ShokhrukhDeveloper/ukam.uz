import 'package:flutter/material.dart';
import 'package:referat/presentation/pages/profile/profile_view_widget/profile_subscribe_widget.dart';

class ProfileSettingsWidget {
  static profileSettingsWidget(BuildContext context, controller) {
    return SizedBox(
      height: MediaQuery.of(context).size.height * 0.65,
      width: MediaQuery.of(context).size.width * 0.65,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          //? Upload Image (Icon,Text)
          Padding(
            padding: const EdgeInsets.only(top: 45, bottom: 35),
            child: InkWell(
              onTap: () async {
                await showModalBottomSheet(
                  backgroundColor: Colors.transparent,
                  context: context,
                  builder: (_) {
                    return SizedBox(
                      height: 180,
                      child: Padding(
                        padding: const EdgeInsets.all(8.0),
                        child: Column(
                          mainAxisAlignment: MainAxisAlignment.end,
                          children: [
                            InkWell(
                              onTap: () async {
                                // await pickImage();
                                Navigator.pop(context);
                              },
                              child: Container(
                                height: 50,
                                width: MediaQuery.of(context).size.width,
                                alignment: Alignment.center,
                                decoration: const BoxDecoration(
                                  color: Colors.white,
                                  borderRadius: BorderRadius.only(
                                    topLeft: Radius.circular(12),
                                    topRight: Radius.circular(12),
                                  ),
                                ),
                                child: const Text(
                                  'Rasmga olish',
                                ),
                              ),
                            ),
                            InkWell(
                              onTap: () async {
                                // await pickImage();
                                Navigator.pop(context);
                              },
                              child: Container(
                                alignment: Alignment.center,
                                height: 50,
                                width: MediaQuery.of(context).size.width,
                                decoration: const BoxDecoration(
                                  color: Colors.white,
                                  borderRadius: BorderRadius.only(
                                    bottomLeft: Radius.circular(12),
                                    bottomRight: Radius.circular(12),
                                  ),
                                ),
                                child: const Text('Galeriyadan tanlash'),
                              ),
                            ),
                            const SizedBox(height: 8),
                            InkWell(
                              onTap: () => Navigator.pop(context),
                              child: Container(
                                height: 50,
                                width: MediaQuery.of(context).size.width,
                                alignment: Alignment.center,
                                decoration: BoxDecoration(
                                  color: Colors.white,
                                  borderRadius: BorderRadius.circular(16),
                                ),
                                child: const Text('Bekor qilish'),
                              ),
                            ),
                          ],
                        ),
                      ),
                    );
                  },
                );
              },
              child: Row(
                children: const [
                  // image == null ?
                  Icon(
                    Icons.account_circle_outlined,
                    color: Colors.greenAccent,
                    size: 64,
                  ),
                  // :
                  // Container(
                  //     height: 64,
                  //     width: 64,
                  //     decoration: BoxDecoration(
                  //       borderRadius: BorderRadius.circular(72),
                  //       image: DecorationImage(
                  //         fit: BoxFit.cover,
                  //         image: FileImage(image!),
                  //       ),
                  //     ),
                  //   ),
                  SizedBox(width: 20),
                  Text('Сурат юклаш',
                      style: TextStyle(color: Colors.greenAccent)),
                ],
              ),
            ),
          ),
          //? Text(Ismingiz)
          const Text('Исмингиз'),
          const SizedBox(height: 10),
          //? TextFormField(Ismingiz kiriting)
          SizedBox(
            height: 50,
            width: 343,
            child: TextFormField(
              controller: controller,
              decoration: InputDecoration(
                hintText: 'Исмингиз',
                hintStyle: const TextStyle(height: 2, color: Colors.grey),
                border: OutlineInputBorder(
                  borderRadius: BorderRadius.circular(16),
                  borderSide: const BorderSide(color: Colors.grey),
                ),
              ),
            ),
          ),
          const SizedBox(height: 65),
          elevatedButton(context, () {}, 'Сақлаш', Color(0xff64C962), 343, h: 50),
        ],
      ),
    );
  }
}
