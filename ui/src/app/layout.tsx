import type { Metadata } from "next";
import { Kanit } from "next/font/google";
import "./globals.css";

export const kanit = Kanit({
  subsets: ["latin"],
  weight: ["100", "200", "300", "400", "500", "600", "700", "800", "900"],
  display: "swap",
  style: ["normal", "italic"],
  variable: "--font-kanit",
});

export const metadata: Metadata = {
  title: "Create Next App",
  description: "Don't just rep you're favourite players, invest in them!",
};

export default function RootLayout({ children }: Readonly<{ children: React.ReactNode; }>) {
  return (
    <html lang="en">
      <body className={`${kanit.variable} antialiased`}>
        {children}
      </body>
    </html>
  );
}
