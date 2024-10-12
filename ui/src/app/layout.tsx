import type { Metadata } from "next";
import { Kanit } from "next/font/google";
import "./globals.css";
import { ClerkProvider } from "@clerk/nextjs";

export const kanit = Kanit({
  weight: ["100", "200", "300", "400", "500", "600", "700", "800", "900"],
  display: "swap",
  style: ["normal", "italic"],
  subsets: ["latin"],
});

export const metadata: Metadata = {
  title: "FootyFolio",
  description: "Generated by create next app",
};

export default function RootLayout({ children }: Readonly<{ children: React.ReactNode; }>) {
  return (
    <ClerkProvider afterSignOutUrl={'/'} signInFallbackRedirectUrl={'/hub'} signUpFallbackRedirectUrl={'/hub'}>
      <html lang="en">
        <body className={`${kanit.className} antialiased`}>
          {children}
        </body>
      </html>
    </ClerkProvider>
  );
}
