import 'package:flutter/material.dart';
import 'package:referat/presentation/pages/profile/profile_view_widget/profile_books_widget.dart';

import 'profile_view_widget/profile_settings_widget.dart';

class ProfileView extends StatefulWidget {
  const ProfileView({Key? key}) : super(key: key);

  @override
  State<ProfileView> createState() => _ProfileViewState();
}

class _ProfileViewState extends State<ProfileView>
    with TickerProviderStateMixin {
  int selectIndex = 0;
  TabController? controllertab;

  var myTabs = ['Аудиокитоб', 'Электрон китоб', 'Босма китоб'];
  @override
  void initState() {
    super.initState();
    controllertab = TabController(length: 3, vsync: this);
  }

  TextEditingController controller = TextEditingController();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Padding(
        padding: const EdgeInsets.only(top: 50, left: 75, right: 75, bottom: 0),
        child: Column(
          children: [
            userInfo(),
            const SizedBox(height: 60),
            Row(
              crossAxisAlignment: CrossAxisAlignment.start,
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Container(
                  height: 380,
                  width: 288,
                  color: Colors.grey,
                  child: NavigationRail(
                      onDestinationSelected: (int index) {
                        setState(() {
                          selectIndex = index;
                        });
                      },
                      destinations: const [
                        NavigationRailDestination(
                          icon: Icon(Icons.sell),
                          label: Text(
                            'Обуна бўлиш',
                            style: TextStyle(color: Colors.black),
                          ),
                        ),
                        NavigationRailDestination(
                          icon: Icon(
                            Icons.wallet_giftcard,
                          ),
                          label: Text(
                            'Э-Хисобme',
                            style: TextStyle(color: Colors.black),
                          ),
                        ),
                        NavigationRailDestination(
                          icon: Icon(Icons.book),
                          label: Text(
                            'Китобларим',
                            style: TextStyle(color: Colors.black),
                          ),
                        ),
                        NavigationRailDestination(
                          icon: Icon(Icons.bookmark),
                          label: Text(
                            'Сақланганлар',
                            style: TextStyle(color: Colors.black),
                          ),
                        ),
                        NavigationRailDestination(
                          icon: Icon(Icons.settings),
                          label: Text(
                            'Созламалар',
                            style: TextStyle(color: Colors.black),
                          ),
                        ),
                      ],
                      selectedIndex: selectIndex),
                ),
                //? Profile Settings
                ProfileSettingsWidget.profileSettingsWidget(
                    context, controller),
                //? Profile Subscribe
                // ProfileSubscribeWidget.profileSubscribeWidget(context),
                //? Profile Wallet
                // ProfileWalletWidget.profileWalletWidget(context),
                //? Profile Saved
                // ProfileSavedWidget.profileSavedWidget(context),
                //? Profile Books
                // ProfileBooksWidget.profileBooksWidget(
                //     context, controllertab),
              ],
            ),
          ],
        ),
      ),
    );
  }

  Card userInfo() {
    return Card(
      elevation: 0.6,
      child: Padding(
        padding: const EdgeInsets.all(24),
        child: Row(
          children: [
            const Padding(
              padding: EdgeInsets.symmetric(horizontal: 24),
              child: CircleAvatar(
                  radius: 40,
                  backgroundImage:
                      NetworkImage('https://source.unsplash.com/random')),
            ),
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
              children: const [
                Text(
                  'Суғдиёна Икромова',
                  style: TextStyle(
                    color: Color(0xff11142D),
                    fontWeight: FontWeight.bold,
                    fontSize: 30,
                  ),
                ),
                Text(
                  '+998 90 253 77 53',
                  style: TextStyle(
                    color: Color(0xff242424),
                    fontSize: 20,
                  ),
                ),
                Text(
                  'ID: 0001  Баланс: 45 000 сўм',
                  style: TextStyle(
                    color: Color(0xff9A9A9A),
                    fontSize: 20,
                  ),
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
